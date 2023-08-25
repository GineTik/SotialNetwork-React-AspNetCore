import { AxiosResponse } from "axios";
import IAuthenticationResult from "../models/authentication/authentication.result";
import ILogin from "../models/authentication/login.model";
import IRegistration from "../models/authentication/registration.model";
import ServerService from "./server.service";

export default class AuthenticationService extends ServerService {

    private static urlPrefix: string = "/authentication";

    async login(data: ILogin): Promise<AxiosResponse<IAuthenticationResult, any>> {
        return await this.post({
            url: AuthenticationService.urlPrefix + "/login",
            data
        }, false);
    }

    async registration(data: IRegistration): Promise<AxiosResponse<IAuthenticationResult, any>> {
        return await this.post({
            url: AuthenticationService.urlPrefix + "/registration",
            data
        }, false);
    }
}