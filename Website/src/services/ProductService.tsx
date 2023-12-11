import axios from "axios";
import baseURL from "./Constants";
import Product from "../models/Product";
import Category from "../models/Category";

const url = `${baseURL}/api/Product`;

export async function getAllProducts(): Promise<Product[] | null> {
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

export async function getProductsByCategory(category: Category): Promise<Product[]> {
    try {
        const response = await axios.get(`${url}?category=${category}`);

        if (response.status === 200) {
            return response.data;
        } else {
            return [];
        }
    }
    catch (e) {
        console.error(e);
        return [];
    }
}

export async function getProductById(id: number): Promise<Product | null> {
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