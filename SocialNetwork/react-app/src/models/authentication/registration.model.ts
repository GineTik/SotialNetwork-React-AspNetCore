export default interface IRegistration {
    email: string;
    username: string;
    password: string;
}

export class RegistrationFormFields implements IRegistration {
    email: string = "";
    username: string = "";
    password: string = "";
}