import { createContext, ProviderProps, useContext, useState } from "react";
import { CONTAINS } from "../../contains/contains";
import IAuthenticationResult from "../../models/authentication/authentication.result";
import IUser from "../../models/user/user.model";

export interface IUseCustomAuth {
    isLoggedIn: boolean;
    token: string | null;
    setToken: (token: string) => void;
    user: IUser | null;
    login: (authenticationResult: IAuthenticationResult) => void;
    logout: () => void;
}

const authContext = createContext<IUseCustomAuth>({} as IUseCustomAuth);

export function AuthProvider({ children }: { children: any }) {
    const authProvider = useProvideAuth();
    return <authContext.Provider value={authProvider}>{children}</authContext.Provider>
}

export function useAuth() {
    return useContext(authContext);
}

function useProvideAuth(): IUseCustomAuth {
    const [token, setTokenForRerender] = useState(getToken());
    const [user, setUserForRerender] = useState(getUser());

    return {
        isLoggedIn: token != null,
        token: token,
        setToken: (token: string) => {
            setToken(token);
        },
        user: user,
        login: (authenticationResult) => {
            setToken(authenticationResult.accessToken);
            setUser(authenticationResult.userInfo);
        },
        logout: () => {
            removeToken();
            removeUser();
        }
    }

    function setToken(token: string): void {
        window.localStorage.setItem(CONTAINS.STORAGE_KEYS.ACCESS_TOKEN, token);
        setTokenForRerender(token);
    }

    function getToken(): string | null {
        return window.localStorage.getItem(CONTAINS.STORAGE_KEYS.ACCESS_TOKEN);
    }

    function removeToken(): void {
        window.localStorage.removeItem(CONTAINS.STORAGE_KEYS.ACCESS_TOKEN);
        setTokenForRerender(null);
    }

    function setUser(userInfo: IUser): void {
        const userInfoJson = JSON.stringify(userInfo);
        window.localStorage.setItem(CONTAINS.STORAGE_KEYS.USER_INFO, userInfoJson);
        setUserForRerender(userInfo);
    }

    function getUser(): IUser | null {
        const userInfoJson = window.localStorage.getItem(CONTAINS.STORAGE_KEYS.USER_INFO);

        if (userInfoJson != null) {
            return JSON.parse(userInfoJson);
        }

        return null;
    }

    function removeUser(): void {
        window.localStorage.removeItem(CONTAINS.STORAGE_KEYS.USER_INFO);
        setUserForRerender(null);
    }
}