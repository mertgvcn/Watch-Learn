import { useState, useEffect } from "react";
//models
import { Roles } from "../models/enumerators/Roles";
import { CreateAccessTokenByRefreshTokenRequest } from "../models/paramaterModels/Authentication/CreateAccessTokenByRefreshTokenRequest";
import { CreateAccessTokenByRefreshTokenResponse } from "../models/paramaterModels/Authentication/CreateAccessTokenByRefreshTokenResponse";
import { CheckRefreshTokenRequest } from "../models/paramaterModels/Authentication/CheckRefreshTokenRequest";
import { TokenViewModel } from "../models/viewModels/JWTTokenViewModel";
//helpers
import AuthenticationAPI from "../APIs/AuthenticationAPI";
import { jwtDecode } from "jwt-decode";
import { deleteCookie, getCookie, setCookie } from "../utils/Cookie";
import { isAccessTokenExpired } from "../utils/Token";

export const useAuth = () => {
    const [userRole, setUserRole] = useState<Roles>(Roles.Guest);
    const [loading, setLoading] = useState(false)

    useEffect(() => {
        checkSessionAsync();
    }, []);

    const checkSessionAsync = async () => {
        setLoading(true)
        await checkSession(setUserRole)
        setLoading(false)
    }

    return { userRole, loading };
};

const decodeAndSetUserRole = (accessToken: string, setUserRole: React.Dispatch<React.SetStateAction<Roles>>): void => {
    const decodedToken = jwtDecode<TokenViewModel>(accessToken);
    setUserRole(Roles[decodedToken.role as keyof typeof Roles]);
}

const createAccessToken = async (refreshToken: string): Promise<string | null> => {
    try {
        const request: CreateAccessTokenByRefreshTokenRequest = { refreshToken }
        const response = await AuthenticationAPI.CreateAccessTokenByRefreshToken(request)

        if (response.status === 200) {
            const data: CreateAccessTokenByRefreshTokenResponse = response.data
            setCookie("jwt", data.accessToken, data.accessTokenExpireDate)
            return data.accessToken;
        }

        return null
    }
    catch (error) {
        return null
    }
}

const checkSession = async (setUserRole: React.Dispatch<React.SetStateAction<Roles>>): Promise<void> => {
    const refreshToken = getCookie("refresh")
    if (!refreshToken) return;


    const checkRefreshTokenRequest: CheckRefreshTokenRequest = { refreshToken }
    const response = await AuthenticationAPI.CheckRefreshToken(checkRefreshTokenRequest)
    if (response.status == 200) {

        let accessToken: string | null = getCookie("jwt")
        if (accessToken && !isAccessTokenExpired(accessToken)) {
            decodeAndSetUserRole(accessToken, setUserRole)
            return;
        }

        //valid refresh token but expired access token, create new access token
        accessToken = await createAccessToken(refreshToken)
        if (accessToken) {
            decodeAndSetUserRole(accessToken, setUserRole)
            return;
        }
    }
    else {
        deleteCookie("refresh")
        window.location.href = "/login"
    }
}

