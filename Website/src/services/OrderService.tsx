import axios from "axios";
import baseURL from "./Constants";
import Order from "../models/Order";

const url = `${baseURL}/api/Order`;

export async function getOrdersFromCustomer(email: string): Promise<Order[]> {
    try {
        const response = await axios.get(`${url}/customer/${email}`);

        if (response.status === 200) {
            const orders: Order[] = response.data.map((order: any) => {
                let date = order.dateTime.split('T')[0];
                let time = order.dateTime.split('T')[1].split('.')[0];
                return new Order(order.id, date, time, order.customerEmail);
            });
            return orders;
        } else {
            return [];
        }
    }
    catch (e) {
        console.error(e);
        return [];
    }
}