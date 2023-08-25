import { Route, Routes } from "react-router-dom";
import RequireAnonimity from "../components/Authentication/RequireAnonymity";
import RequireAuthentication from "../components/Authentication/RequireAuth";
import LoginPage from "../pages/authentication/LoginPage";
import RegistrationPage from "../pages/authentication/RegistrationPage";
import HomePage from "../pages/HomePage";
import ProfilePage from "../pages/ProfilePage";

export default function ConfiguredRouter() {
    return (
        <Routes>
            <Route
                path="/"
                element={<HomePage />}
            />
            <Route
                path="/login"
                element={
                    <RequireAnonimity redirectTo="/">
                        <LoginPage />
                    </RequireAnonimity>
                }
            />
            <Route
                path="/registration"
                element={
                    <RequireAnonimity redirectTo="/">
                        <RegistrationPage />
                    </RequireAnonimity>
                }
            />
            <Route
                path="/profile"
                element={
                    <RequireAuthentication redirectTo="/login">
                        <ProfilePage />
                    </RequireAuthentication>
                }
            />
        </Routes>
    );
}