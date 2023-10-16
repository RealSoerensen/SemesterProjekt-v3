import axios from "axios";
import baseURL from "./Constants";

const url = `${baseURL}/api/Order`;

export async function getOrdersFromCustomer() {
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