import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from "axios";
import { getCookie, setCookie } from "../Cookie";
import { CreateAccessTokenByRefreshTokenRequest } from "../../models/paramaterModels/Authentication/CreateAccessTokenByRefreshTokenRequest";
import AuthenticationAPI from "./AuthenticationAPI";
import { isAccessTokenExpired } from "../Token";

export abstract class BaseAPI {
    protected axiosInstance: AxiosInstance | any = null;

    constructor() {
        this.axiosInstance = axios.create({
            baseURL: process.env.REACT_APP_BASEURL
        });

        this.initializeInterceptors();
    }

    protected async get(endpoint?: string, params?: any): Promise<AxiosResponse> {
        const response: AxiosResponse = await this.axiosInstance.get(endpoint, params)
        this.CheckResponseCode(response.status)

        return response
    }

    protected async post(endpoint: string, params?: any): Promise<AxiosResponse> {
        const response: AxiosResponse = await this.axiosInstance.post(endpoint, params)
        this.CheckResponseCode(response.status);

        return response
    }

    private CheckResponseCode(statusCode: number) {
        if (!statusCode.toString().startsWith("2"))
            throw new Error("Call has not succeed")
    }

    private initializeInterceptors() {
        this.axiosInstance.interceptors.request.use(
            async (config: AxiosRequestConfig) => {
                config.headers = config.headers || {};

                const accessToken = getCookie("jwt")
                if (accessToken && !isAccessTokenExpired(accessToken)) {
                    config.headers.Authorization = `Bearer ${accessToken}`;
                }

                return config;
            },
            (error: any) => {
                return Promise.reject(error);
            }
        );

        this.axiosInstance.interceptors.response.use(
            (response: AxiosResponse) => {
                return response;
            },
            async (error: any) => {
                const originalRequest = error.config

                if (error.response.status == 401 && !originalRequest._retry) {
                    originalRequest._retry = true

                    try {
                        const request: CreateAccessTokenByRefreshTokenRequest = {
                            accessToken: getCookie("jwt"),
                            refreshToken: getCookie("refresh")
                        }

                        const response = await AuthenticationAPI.CreateAccessTokenByRefreshToken(request)

                        if (response) {
                            setCookie("jwt", response.accessToken, response.accessTokenExpireDate)

                            this.axiosInstance.defaults.headers.common['Authorization'] = `Bearer ${response.accessToken}`;
                            originalRequest.headers['Authorization'] = `Bearer ${response.accessToken}`;

                            return this.axiosInstance(originalRequest);
                        }
                    }
                    catch (refreshError) {
                        return Promise.reject(refreshError)
                    }
                }
                return Promise.reject(error);
            }
        );
    }
}