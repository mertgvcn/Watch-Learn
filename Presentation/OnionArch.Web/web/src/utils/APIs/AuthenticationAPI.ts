import { BaseAPI } from "./BaseAPI";
//models
import { UserLoginRequest } from "../../models/paramaterModels/Authentication/UserLoginRequest";
import { UserLoginResponse } from "../../models/paramaterModels/Authentication/UserLoginResponse";
import { UserRegisterRequest } from "../../models/paramaterModels/Authentication/UserRegisterRequest";
import { CreateAccessTokenByRefreshTokenRequest } from "../../models/paramaterModels/Authentication/CreateAccessTokenByRefreshTokenRequest";
import { CreateAccessTokenByRefreshTokenResponse } from "../../models/paramaterModels/Authentication/CreateAccessTokenByRefreshTokenResponse";
import { AxiosResponse } from "axios";

class AuthenticationAPI extends BaseAPI {
    private controllerExtension: string = "/Authentication"

    constructor() {
        super();
    }

    public async Login(params: UserLoginRequest): Promise<UserLoginResponse> {
        const response: AxiosResponse = await this.post(this.controllerExtension + '/Login', params)
        return response.data;
    }

    public async Register(params: UserRegisterRequest): Promise<void> {
        const response: AxiosResponse = await this.post(this.controllerExtension + '/Register', params)
        return response.data;
    }

    public async CreateAccessTokenByRefreshToken(params: CreateAccessTokenByRefreshTokenRequest): Promise<CreateAccessTokenByRefreshTokenResponse> {
        const response: AxiosResponse = await this.post(this.controllerExtension + '/CreateAccessTokenByRefreshToken', params)
        return response.data;
    }
}

export default new AuthenticationAPI()