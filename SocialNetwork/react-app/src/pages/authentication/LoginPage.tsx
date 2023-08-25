import { useNavigate } from "react-router-dom";
import CustomForm from "../../components/common/CustomForm";
import { useAuth } from "../../hooks/authentication/customAuth.hook";
import { LoginFormFields } from "../../models/authentication/login.model";
import AuthenticationService from "../../services/authentication.service";

export default function LoginPage() {
    const authenticationService = new AuthenticationService();
    const { login } = useAuth();
    const navigate = useNavigate();

    return (
        <div className="d-flex justify-content-center flex-fill">
            <CustomForm
                fields={new LoginFormFields()}
                clickCallback={async (fields, setErrorMessage) => {
                    try {
                        const response = await authenticationService.login(fields);
                        login(response.data);
                        navigate("/");
                    } catch (error) {
                        console.log(error);
                        setErrorMessage("Email or password incorrect");
                    }
                }}
                buttonText="Login"
            />
        </div>
    );
}