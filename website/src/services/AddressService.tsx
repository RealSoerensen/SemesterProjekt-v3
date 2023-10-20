import axios from "axios";
import baseURL from "./Constants";
import Address from "../models/Address";

const url = `${baseURL}/api/Address`;

export async function getAddressById(id: number): Promise<Address | null> {
    try {
        const response = await axios.get(`${url}/${id}`);

        if (response.status === 200) {
            const address: Address = response.data;
            return address;
        } else {
            return null;
        }
    }
    catch (e) {
        console.error(e);
        return null;
    }
}

export async function updateAddress(address: Address): Promise<boolean> {
    try {
        const response = await axios.put(`${url}`, address);

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