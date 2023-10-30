import { useContext, useEffect, useState } from "react";
import Order from "../../models/Order";
import { AuthContext } from "../../contexts/AuthContext";
import { getOrdersFromCustomer } from "../../services/OrderService";
import { getOrderslinesFromOrderID } from "../../services/OrderlineService";
import Orderline from "../../models/Orderline";
import Product from "../../models/Product";
import 'bootstrap/dist/js/bootstrap.js';
import { getProductById } from "../../services/ProductService";
import Image from "../../components/Image";

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
        return total;
    }
}

const Orders = () => {
    const [completeOrders, setCompleteOrders] = useState<CompleteOrder[]>([]);
    const { customer } = useContext(AuthContext);

    useEffect(() => {
        const fetchOrders = async () => {
            if (customer) {
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
            }
        };

        fetchOrders();
    }, [customer]);

    return (
        <div>
            <h1>Bestillinger</h1>
            <div className="row">
                {completeOrders.map((completeOrder, index) => (
                    <div className="col-sm-12 col-md-4 d-flex justify-content-center" key={index}>
                        <div className="card m-1">
                            <div className="card-body">
                                <p>Ordrenummer: {completeOrder.order.id}</p>
                                <p>Oprettet: {completeOrder.order.date.toDateString()}</p>
                                <p>Pris: {completeOrder.totalPrice()} kr.</p>
                            </div>
                            <hr />
                            <div className="text-center mb-3">
                                <button
                                    className="btn btn-primary"
                                    type="button"
                                    data-bs-toggle="collapse"
                                    data-bs-target={`#collapse${index}`}
                                    aria-expanded="false"
                                    aria-controls={`collapse${index}`}
                                >
                                    Vis bestilling
                                </button>
                            </div>

                            <div className="collapse" id={`collapse${index}`}>
                                <hr />
                                <div className="row">
                                    {Array.from(completeOrder.products.values()).map((product: Product, index: number) => {
                                        const orderline = completeOrder.orderlines.get(product.id);
                                        if (orderline && product) {
                                            return (
                                                <div className="col-12" key={index}>
                                                    <div className="card-body">
                                                        <div className="row">
                                                            <div className="col-4">
                                                                <Image image={product.image} imageTitle={product.name} className="img-fluid" />
                                                            </div>
                                                            <div className="col-8">
                                                                <p className="fw-bold">{product.name}</p>
                                                                <p className="fw-bold">{orderline.quantity} stk.</p>
                                                                <p className="fw-bold">{orderline.priceAtTimeOfOrder} kr.</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            );
                                        }
                                        return null;
                                    })}
                                </div>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};


export default Orders;
