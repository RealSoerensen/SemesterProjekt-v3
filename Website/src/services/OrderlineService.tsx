import axios from "axios";
import baseURL from "./Constants";
import Orderline from "../models/Orderline";

const url = `${baseURL}/api/Orderline`;

export async function getOrderslinesFromOrderID(id: number): Promise<Orderline[]> {
    try {
        const response = await axios.get(`${url}/${id}`);

        if (response.status === 200) {
            const orderlines: Orderline[] = response.data.map((orderline: Orderline) => {
                if (orderline === null) {
                    throw new Error("Orderline ID is null");
                }
                return new Orderline(id, orderline.productID, orderline.quantity);
            });
            return orderlines;
        } else {
            return [];
        }
    }
    catch (e) {
        console.error(e);
        return [];
    }
}