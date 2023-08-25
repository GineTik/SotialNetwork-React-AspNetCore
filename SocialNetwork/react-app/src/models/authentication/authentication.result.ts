import IUser from "../user/user.model";

export default interface IAuthenticationResult {
    accessToken: string;
    userInfo: IUser;
}