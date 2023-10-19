import axios from "axios";
import baseURL from "./Constants";
import ProductDescription from "../models/ProductDescription";

const url = `${baseURL}/api/ProductDescription`;

export async function getAllProductDescription(): Promise<ProductDescription[] | null> {
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

export async function getProductDescriptionById(id: number): Promise<ProductDescription | null> {
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
