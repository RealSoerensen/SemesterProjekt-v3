import { Dispatch, FC, ReactNode, SetStateAction, createContext, useEffect, useState } from "react";
import { UserAccount } from "../models/UserAccount";

interface AuthContextType {
    user: UserAccount | null;
    setUser: Dispatch<SetStateAction<UserAccount | null>>;
}

interface AuthProviderProps {
    children: ReactNode;
}

export const AuthContext = createContext<AuthContextType>({
    user: null,
    setUser: () => { },
});

export const AuthProvider: FC<AuthProviderProps> = ({ children }) => {
    const [user, setUser] = useState<UserAccount | null>(() => {
        const userString = localStorage.getItem('user');
        if (userString) {
            const user: UserAccount = JSON.parse(userString);
            return user;
        }
        return null;
    });

    // Update the token in localStorage whenever it changes
    useEffect(() => {
        if (user) {
            localStorage.setItem('user', JSON.stringify(user));
        } else {
            localStorage.removeItem('user');
        }
    }, [user]);

    return (
        <AuthContext.Provider value={{ user, setUser }}>
            {children}
        </AuthContext.Provider>
    );
};