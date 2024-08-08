export type UserLoginResponse = {
    accessToken: string,
    accessTokenExpireDate: Date,
    refreshToken: string,
    refreshTokenExpireDate: Date
}