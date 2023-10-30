import axios from "axios";
import baseURL from "./Constants";

const url = `${baseURL}/api/Product`;

export async function getAllProducts() {
    try {
        const response = await axios.get(`${url}`);

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

export async function getProductById(id: number) {
    try {
        const response = await axios.get(`${url}/${id}`);

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

export async function getProductsByCategory(category: number) {
    try {
        const response = await axios.get(`${url}/category/${category}`);

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