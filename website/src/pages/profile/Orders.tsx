import { useContext, useEffect, useState } from "react";
import Order from "../../models/Order";
import { AuthContext } from "../../contexts/AuthContext";
import { getOrdersFromCustomer } from "../../services/OrderService";
import { getProductById } from "../../services/ProductService";
import Orderline from "../../models/Orderline";
import Product from "../../models/Product";
import OrderCard from "../../components/OrderCard";
import LoadingSpinner from "../../components/Spinner";
import { getOrderslinesFromOrderID } from "../../services/OrderlineService";

class CompleteOrder {
    order: Order;
    orderlines: Map<number, Orderline>;
    products: Map<number, Product>;

    constructor(order: Order, orderlines: Orderline[], products: Product[]) {
        this.order = order;
        this.orderlines = new Map<number, Orderline>(orderlines.map((ol) => [ol.productID, ol]));
        this.products = new Map<number, Product>(products.map((p) => [p.id, p]));
    }

    totalPrice(): number {
        let total = 0;
        this.orderlines.forEach((orderline) => {
            total += orderline.quantity * orderline.priceAtTimeOfOrder;
        });
        return Math.round(total * 100) / 100;
    }
}

const Orders = () => {
    const [completeOrders, setCompleteOrders] = useState<CompleteOrder[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const { user } = useContext(AuthContext);

    useEffect(() => {
        const fetchOrders = async () => {
            if (user) {
                setIsLoading(true);
                try {
                    const customerOrders = await getOrdersFromCustomer(user.customerID);
                    const updatedCompleteOrders = await Promise.all(
                        customerOrders.map(async (order) => {
                            const orderlines = await getOrderslinesFromOrderID(order.id);
                            const completeOrders = (await Promise.all(orderlines.map(async (orderline: Orderline) =>
                                await getProductById(orderline.productID)))).filter(product => product !== null);
                            return new CompleteOrder(order, orderlines, completeOrders as Product[]);
                        })
                    );

                    setCompleteOrders(updatedCompleteOrders);
                } catch (error) {
                    // Handle any errors here
                    console.error("Error fetching orders:", error);
                } finally {
                    setIsLoading(false);
                }
            }
        };

        fetchOrders();
    }, [user]);

    return (
        <div>
            <h1>Dine bestillinger</h1>
            <div className="row">
                {isLoading ? (
                    <LoadingSpinner />
                ) : (
                    completeOrders.map((completeOrder, index) => (
                        <div className="col-4" key={index}>
                            <OrderCard completeOrder={completeOrder} index={index} />
                        </div>
                    ))
                )}
            </div>
        </div>
    );
};

export default Orders;
