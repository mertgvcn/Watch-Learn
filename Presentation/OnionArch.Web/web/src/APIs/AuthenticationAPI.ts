import { BaseAPI } from "./BaseAPI";
//models
import { AxiosResponse } from "axios";
import { UserLoginRequest } from "../../models/paramaterModels/Authentication/UserLoginRequest";
import { UserRegisterRequest } from "../../models/paramaterModels/Authentication/UserRegisterRequest";
import { CreateAccessTokenByRefreshTokenRequest } from "../../models/paramaterModels/Authentication/CreateAccessTokenByRefreshTokenRequest";
import { CheckRefreshTokenRequest } from "../../models/paramaterModels/Authentication/CheckRefreshTokenRequest";

class AuthenticationAPI extends BaseAPI {
    private controllerExtension: string = "/Authentication"

    constructor() {
        super();
    }

    public async Login(params: UserLoginRequest): Promise<AxiosResponse> {
        return await this.post(this.controllerExtension + '/Login', params)
    }

    public async Register(params: UserRegisterRequest): Promise<AxiosResponse> {
        return await this.post(this.controllerExtension + '/Register', params)
    }

    public async CreateAccessTokenByRefreshToken(params: CreateAccessTokenByRefreshTokenRequest): Promise<AxiosResponse> {
        return await this.post(this.controllerExtension + '/CreateAccessTokenByRefreshToken', params)
    }

    public async CheckRefreshToken(params: CheckRefreshTokenRequest) : Promise<AxiosResponse> {
        return await this.post(this.controllerExtension + '/CheckRefreshToken', params)
    }

    public async RevokeRefreshToken() : Promise<AxiosResponse> {
        return await this.delete(this.controllerExtension + '/RevokeRefreshToken')
    }
}

export default new AuthenticationAPI()