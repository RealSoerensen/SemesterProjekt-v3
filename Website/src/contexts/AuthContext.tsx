import { Dispatch, FC, ReactNode, SetStateAction, createContext, useEffect, useState } from "react";
import Customer from "../models/Customer";

interface AuthContextType {
    customer: Customer | null;
    setCustomer: Dispatch<SetStateAction<Customer | null>>;
}

interface AuthProviderProps {
    children: ReactNode;
}

export const AuthContext = createContext<AuthContextType>({
    customer: null,
    setCustomer: () => { },
});

export const AuthProvider: FC<AuthProviderProps> = ({ children }) => {
    const [customer, setCustomer] = useState<Customer | null>(() => {
        const customerString = localStorage.getItem('customer');
        if (customerString) {
            const customer: Customer = JSON.parse(customerString);
            return customer;
        }
        return null;
    });

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