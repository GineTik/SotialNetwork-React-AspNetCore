import axios, { AxiosInstance, AxiosResponse } from "axios";
import { CONTAINS } from "../contains/contains";

export default abstract class ServerService {
    private readonly api: AxiosInstance;

    constructor() {
        this.api = axios.create({
            baseURL: CONTAINS.SERVER.URL,
        });
    }

    protected post(
        config: { url: any; data?: any; headers?: any },
        withAuthentication = true): Promise<AxiosResponse<any, any>> {

        return this.send('post', config, withAuthentication);
    }

    protected get(
        config: { url: any; data?: any; headers?: any },
        withAuthentication = true): Promise<AxiosResponse<any, any>> {

        return this.send('get', config, withAuthentication);
    }

    private async send(
        method: string,
        config: { [keys: string]: any; headers?: any; url: any; data?: any },
        withAuthentication: boolean = true): Promise<AxiosResponse<any, any>> {

        let fullConfig = {
            method,
            ...config
        };

        if (withAuthentication == true) {
            fullConfig.headers = {
                ...config.headers,
            };
        }

        return await this.api
            .request(fullConfig);
    }
}