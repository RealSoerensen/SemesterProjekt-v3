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

export async function createCustomer(customer: Customer): Promise<boolean> {
    try {
        const response = await axios.post(`${url}`, customer);

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
