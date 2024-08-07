import { useEffect, useState } from "react";
//router manager
import RouterManager from "./routers/RouterManager";
//models
import { Roles } from "./models/enumerators/Roles";
import { TokenViewModel } from "./models/viewModels/JWTTokenViewModel";
import { CreateAccessTokenByRefreshTokenRequest } from "./models/paramaterModels/Authentication/CreateAccessTokenByRefreshTokenRequest";
//helpers
import AuthenticationAPI from "./utils/APIs/AuthenticationAPI";
import { getCookie, setCookie } from "./utils/Cookie";
import { jwtDecode } from "jwt-decode";
import { isAccessTokenExpired } from "./utils/Token";

function App() {
    const [userRole, setUserRole] = useState<Roles>(Roles.Guest)

    useEffect(() => {
        checkSession()
    }, [])

    const checkSession = async () => {
        const refreshToken = getCookie("refresh")
        var accessToken = getCookie("jwt")

        if (refreshToken) { //isRefreshTokenExpired lazım 
            if (isAccessTokenExpired(accessToken)) {
                try {
                    const request: CreateAccessTokenByRefreshTokenRequest = {
                        accessToken: accessToken,
                        refreshToken: refreshToken
                    }

                    const response = await AuthenticationAPI.CreateAccessTokenByRefreshToken(request)

                    if (response) {
                        setCookie("jwt", response.accessToken, response.accessTokenExpireDate)
                        accessToken = response.accessToken
                    }
                }
                catch (error) {
                    console.error("Failed to refresh access token:", error)
                }
            }

            const decodedToken = jwtDecode<TokenViewModel>(accessToken)
            setUserRole(Roles[decodedToken.role as keyof typeof Roles])
        }
    }

    return (
        <RouterManager userRole={userRole} />
    );
}

export default App;
