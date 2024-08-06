import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from "axios";

export abstract class BaseAPI {
  protected axiosInstance: AxiosInstance | any = null;

  constructor() {
    this.axiosInstance = axios.create({
      baseURL: process.env.REACT_APP_BASEURL,
      withCredentials: true,
    });

    this.initializeInterceptors();
  }

  protected async get(endpoint?: string, params?: any): Promise<any> {
    return this.axiosInstance.get(endpoint, params).then((response: any) => {
      return response.data;
    });
  }

  protected async post(endpoint: string, params?: any): Promise<any> {
    return this.axiosInstance.post(endpoint, params).then((response: any) => {
      return response.data;
    });
  }

  private initializeInterceptors() {
    this.axiosInstance.interceptors.request.use(
      (config: AxiosRequestConfig) => {
        const token = localStorage.getItem('token');
        config.headers = config.headers || {};
        if (token) {
          config.headers.Authorization = `Bearer ${token}`;
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
      (error: any) => {
        return Promise.reject(error);
      }
    );
  }
}