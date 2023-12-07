import axios from "axios";
import baseURL from "./Constants";
import Customer from "../models/Customer";

const url = `${baseURL}/api/Customer`;

export async function updateCustomer(customer: Customer): Promise<boolean> {
    try {
        const response = await axios.put(`${url}`, customer);

        if (response.status === 200) {
            return true;
        } else {
            return false;
        }
    }
    catch (e) {
        console.error(e);
        return false;
    }
}

export async function getCustomerById(id: number): Promise<Customer | null> {
    try {
        const response = await axios.get(`${url}/${id}`, {
            withCredentials: true,
        });

        if (response.status === 200) {
            return response.data;
        } else {
            return null;
        }
    }
    catch (e) {
        console.error(e);
        return null;
    }
}

export async function createCustomer(customer: Customer): Promise<Customer | null> {
    try {
        const response = await axios.post(`${url}`, customer, {
            withCredentials: true,
        });

        if (response.status === 200) {
            return response.data;
        } else {
            return null;
        }
    }
    catch (e) {
        console.error(e);
        return null;
    }
}
