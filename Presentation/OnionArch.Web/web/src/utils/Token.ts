import dayjs from "dayjs";
import { TokenViewModel } from "../models/viewModels/JWTTokenViewModel";
import { jwtDecode } from "jwt-decode";

export const isAccessTokenExpired = (accessToken: string | null): boolean => {
    if (!accessToken) return true;

    const decodedToken = jwtDecode<TokenViewModel>(accessToken);
    const expirationTime = dayjs.unix(decodedToken.exp);

    return expirationTime.isBefore(dayjs());
};