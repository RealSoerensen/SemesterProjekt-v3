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

export async function createAddress(address: Address): Promise<Address | null> {
    try {
        const response = await axios.post(`${url}`, address);

        if (response.status === 200) {
            return response.data;
        } else {
            console.error(`Unexpected response status: ${response.status}`);
            return null;
        }
    }
    catch (e) {
        console.error(e);
        return null;
    }
}

export async function deleteAddress(id: number): Promise<boolean> {
    try {
        const response = await axios.delete(`${url}/${id}`);

        if (response.status === 200) {
            return true;
        } else {
            console.error(`Unexpected response status: ${response.status}`);
            return false;
        }
    }
    catch (e) {
        console.error(e);
        return false;
    }
}