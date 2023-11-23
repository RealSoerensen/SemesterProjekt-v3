import { useContext, useEffect, useState } from "react";
import Order from "../../models/Order";
import { AuthContext } from "../../contexts/AuthContext";
import { getOrdersFromCustomer } from "../../services/OrderService";
import { getOrderslinesFromOrderID } from "../../services/OrderlineService";
import { getProductById } from "../../services/ProductService";
import Orderline from "../../models/Orderline";
import Product from "../../models/Product";
import OrderCard from "../../components/OrderCard";
import LoadingSpinner from "../../components/Spinner";

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
    const { customer } = useContext(AuthContext);

    useEffect(() => {
        const fetchOrders = async () => {
            if (customer) {
                setIsLoading(true);
                try {
                    const customerOrders = await getOrdersFromCustomer(customer.id);
                    const updatedCompleteOrders = await Promise.all(
                        customerOrders.map(async (order) => {
                            const orderlines = await getOrderslinesFromOrderID(order.id);
                            const completeProducts = await Promise.all(
                                orderlines.map(async (orderline: Orderline) => await getProductById(orderline.productID))
                            );

                            return new CompleteOrder(order, orderlines, completeProducts);
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
    }, [customer]);

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
