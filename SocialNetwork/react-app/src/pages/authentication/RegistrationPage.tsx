import { useNavigate } from "react-router-dom";
import CustomForm from "../../components/common/CustomForm";
import { useAuth } from "../../hooks/authentication/customAuth.hook";
import { RegistrationFormFields } from "../../models/authentication/registration.model";
import AuthenticationService from "../../services/authentication.service";

export default function RegistrationPage() {
    const authenticationService = new AuthenticationService();
    const { login } = useAuth();
    const navigate = useNavigate();

    return (
        <div className="d-flex justify-content-center flex-fill">
            <CustomForm
                fields={new RegistrationFormFields()}
                clickCallback={async (fields, setErrorMessage) => {
                    try {
                        const response = await authenticationService.registration(fields);
                        login(response.data);
                        navigate("/");
                    } catch (error) {
                        console.log(error);
                        setErrorMessage("Error");
                    }
                }}
                buttonText="Registration"
            />
        </div>
    );
}