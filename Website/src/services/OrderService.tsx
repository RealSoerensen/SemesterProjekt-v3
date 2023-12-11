import axios from "axios";
import baseURL from "./Constants";
import Order from "../models/Order";
import Orderline from "../models/Orderline";

const url = `${baseURL}/api/Order`;

export async function getOrdersFromCustomer(id: number): Promise<Order[]> {
    try {
        const response = await axios.get(`${url}?customerID=${id}`);

        if (response.status === 200) {
            const orders: Order[] = response.data.map((order: any) => {
                const date = order.date.split('T')[0];
                const time = order.date.split('T')[1].split('.')[0];
                return new Order(order.id, date, time, order.customerEmail, order.status);
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

export async function createOrder(customerID: number, orderlines: Orderline[]): Promise<boolean> {
    try {
        const response = await axios.post(`${url}/CreateWithID/${customerID}`, orderlines);
        return response.status === 200;
    }
    catch (e) {
        console.error(e);
        return false;
    }
}