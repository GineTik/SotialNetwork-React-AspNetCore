import { Navigate, To, useLocation } from "react-router-dom";
import { useAuth } from "../../hooks/authentication/customAuth.hook";

export interface IRequireAuthenticationProps {
    children: React.ReactElement,
    redirectTo: To
}

export default function RequireAuthentication({ children }: IRequireAuthenticationProps) {
    let { isLoggedIn } = useAuth();
    let location = useLocation();

    if (isLoggedIn == false) {
        return <Navigate to="/login" state={{ from: location }} />;
    }

    return children;
}
