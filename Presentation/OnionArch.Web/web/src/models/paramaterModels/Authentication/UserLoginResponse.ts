export type UserLoginResponse = {
    isAuthenticated: boolean,
    accessToken: string,
    accessTokenExpireDate: Date,
    refreshToken: string,
    refreshTokenExpireDate: Date
}