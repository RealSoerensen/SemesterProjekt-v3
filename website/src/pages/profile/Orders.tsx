import { useContext, useEffect, useState } from "react";
import Order from "../../models/Order";
import { AuthContext } from "../../contexts/AuthContext";
import { getOrdersFromCustomer } from "../../services/OrderService";
import { getOrderslinesFromOrderID } from "../../services/OrderlineService";
import Orderline from "../../models/Orderline";
import Product from "../../models/Product";
import 'bootstrap/dist/js/bootstrap.js';
import { getProductById } from "../../services/ProductService";
import { getProductDescriptionById } from "../../services/ProductDescription";
import ProductDescription from "../../models/ProductDescription";
import Image from "../../components/Image";

class CompleteProduct {
    product: Product;
    description: ProductDescription;

    constructor(product: Product, description: ProductDescription) {
        this.product = product;
        this.description = description;
    }
}

class CompleteOrder {
    order: Order;
    orderlines: Map<number, Orderline>;
    products: Map<number, CompleteProduct>;

    constructor(order: Order, orderlines: Orderline[], products: CompleteProduct[]) {
        this.order = order;
        this.orderlines = new Map<number, Orderline>();
        this.products = new Map<number, CompleteProduct>();

        orderlines.forEach((orderline: Orderline) => {
            this.orderlines.set(orderline.productID, orderline);
        });

        products.forEach((product: CompleteProduct) => {
            this.products.set(product.product.productSN, product);
        });
    }
}


const Orders = () => {
    const [completeOrders, setCompleteOrders] = useState<CompleteOrder[]>([]);
    const { customer } = useContext(AuthContext);

    const getOrderlines = async (order: Order): Promise<Orderline[]> => {
        const orderlines: Orderline[] = await getOrderslinesFromOrderID(order.id);
        return orderlines;
    };

    useEffect(() => {
        const fetchOrders = async () => {
            if (customer !== null) {
                const customerOrders = await getOrdersFromCustomer(customer.email);

                const updatedCompleteOrders = await Promise.all(customerOrders.map(async (order) => {
                    const orderlines = await getOrderlines(order);

                    const completeProducts = await Promise.all(orderlines.map(async (orderline) => {
                        const product = await getProductById(orderline.productID);
                        const productDescription = await getProductDescriptionById(product.productDescriptionID);
                        return new CompleteProduct(product, productDescription);
                    }));

                    return new CompleteOrder(order, orderlines, completeProducts);
                }));

                setCompleteOrders(updatedCompleteOrders);
            }
        };

        fetchOrders();
    }, [customer]);

    const totalPrice = (order: CompleteOrder): number => {
        let total = 0;
        Array.from(order.orderlines.values()).map((orderline: Orderline) => (
            total += orderline.quantity * completeOrders[0].products.get(orderline.productID)!.description.price
        ));
        return total;
    }

    return (
        <div>
            <h1>Bestillinger</h1>
            <div className="row">
                {completeOrders.map((completeOrder, index) => (
                    <div className="col-sm-12 col-md-6" key={index}>
                        <div className="card m-1">
                            <div className="card-body">
                                <p>Ordrenummer: {completeOrder.order.id}</p>
                                <p>Dato: {completeOrder.order.date.toDateString()}</p>
                                <p>Pris: {totalPrice(completeOrder)} kr.</p>
                            </div>
                            <hr />
                            <div className="text-center mb-3">
                                <button className="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target={`#collapse${index}`} aria-expanded="false" aria-controls={`collapse${index}`}>
                                    Vis bestilling
                                </button>
                            </div>

                            <div className="collapse" id={`collapse${index}`}>
                                <hr />
                                <div className="row">
                                    {Array.from(completeOrder.orderlines.values()).map((orderline: Orderline, index) => (
                                        <div className="container m-1" key={index}>
                                            <div className="row">
                                                <div className="col-4">
                                                    <Image image={completeOrder.products.get(orderline.productID)!.description.image} imageTitle={completeOrder.products.get(orderline.productID)!.description.name} className="img-fluid" />
                                                </div>
                                                <div className="col-8">
                                                    <p>Produkt: {completeOrder.products.get(orderline.productID)?.description.name}</p>
                                                    <p>Antal: {orderline.quantity}</p>
                                                    <p>Pris per stk.: {completeOrder.products.get(orderline.productID)?.description.price}</p>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
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
