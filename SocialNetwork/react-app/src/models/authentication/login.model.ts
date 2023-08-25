
export default interface ILogin {
    email: string;
    password: string;
}

export class LoginFormFields implements ILogin {
    email: string = "";
    password: string = "";
}