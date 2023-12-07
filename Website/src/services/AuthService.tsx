import Address from "../models/Address";
import Customer from "../models/Customer";
import { UserAccount } from "../models/UserAccount";
import baseURL from "./Constants";
import axios from "axios";

const url = `${baseURL}/api/Auth`;

export async function login(email: string, password: string): Promise<Customer | null> {
    try {
        const response = await axios.get(`${url}/login`, {
            params: {
                email,
                password,
            },
            withCredentials: true,
        });

        if (response.status !== 200) {
            return null;
        }

        return response.data;
    }
    catch (e) {
        return null;
    }
}

export async function register(customer: Customer, userAccount: UserAccount, address: Address): Promise<boolean> {
    try {
        const response = await axios.post(`${url}/register`, {
            customer,
            userAccount,
            address,
        });
        return response.status === 200;
    }
    catch (e) {
        console.error(e);
        return false;
    }
}