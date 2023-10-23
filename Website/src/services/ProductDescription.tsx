import axios from "axios";
import baseURL from "./Constants";

const url = `${baseURL}/api/ProductDescription`;

export async function getAllProductDescription() {
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

export async function getProductDescriptionById(id: number) {
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
