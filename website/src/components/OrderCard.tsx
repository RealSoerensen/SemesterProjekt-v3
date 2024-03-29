import { FC } from "react";
import Order from "../models/Order";
import Orderline from "../models/Orderline";
import Product from "../models/Product";
import Image from "./Image";
import { statusToString } from "../models/OrderStatus";
import { Link } from "react-router-dom";

interface OrderCardProps {
    completeOrder: {
        order: Order;
        orderlines: Map<number, Orderline>;
        products: Map<number, Product>;
        totalPrice: () => number;
    };
    index: number;
}

const OrderCard: FC<OrderCardProps> = ({ completeOrder, index }) => {
    return (
        <div>
            <div className="card m-1">
                <div className="card-body">
                    <p>Ordrenummer: {completeOrder.order.id}</p>
                    <p>Oprettet: {completeOrder.order.date.toDateString()}</p>
                    <p>Pris: {completeOrder.totalPrice()} kr.</p>
                    <p>Status: {statusToString(completeOrder.order.status)}</p>
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
                        {Array.from(completeOrder.products.values()).map((product: Product, innerIndex: number) => {
                            const orderline = completeOrder.orderlines.get(product.id);
                            if (!(orderline && product)) return null;
                            return (
                                <div className="col-12" key={innerIndex}>
                                    <div className="card-body">
                                        <div className="row">
                                            <div className="col-4">
                                                <Link to={`/product/${product.id}`} className="text-decoration-none text-dark">
                                                    <Image image={product.image} imageTitle={product.name} className="img-fluid" />
                                                </Link>
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
                        })}
                    </div>
                </div>
            </div>
        </div>
    );
};


export default OrderCard;
