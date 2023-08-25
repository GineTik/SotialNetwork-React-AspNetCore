import { Navigate, To, useLocation } from "react-router-dom";
import { useAuth } from "../../hooks/authentication/customAuth.hook";

export interface IRequireAnonimityProps {
    children: React.ReactElement,
    redirectTo: To
}

export default function RequireAnonimity({ children, redirectTo }: IRequireAnonimityProps) {
    let { isLoggedIn } = useAuth();
    let location = useLocation();

    if (isLoggedIn == true) {
        return <Navigate to={redirectTo} state={{ from: location }} />;
    }

    return children;
}
