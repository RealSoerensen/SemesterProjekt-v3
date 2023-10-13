import { createContext, useEffect, useState } from "react";
import Customer from "../models/Customer";

interface AuthContextType {
    customer: Customer | null;
    setCustomer: React.Dispatch<React.SetStateAction<Customer | null>>;
}

interface AuthProviderProps {
    children: React.ReactNode;
}

export const AuthContext = createContext<AuthContextType>({
    customer: null,
    setCustomer: () => { },
});

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
    const [customer, setCustomer] = useState<Customer | null>(null)

    // Update the token in localStorage whenever it changes
    useEffect(() => {
        if (customer) {
            localStorage.setItem('customer', JSON.stringify(customer));
        } else {
            localStorage.removeItem('customer');
        }
    }, [customer]);

    return (
        <AuthContext.Provider value={{ customer, setCustomer }}>
            {children}
        </AuthContext.Provider>
    );
};