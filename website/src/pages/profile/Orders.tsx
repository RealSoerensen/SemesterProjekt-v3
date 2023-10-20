import { useContext, useEffect, useState } from "react";
import Order from "../../models/Order";
import { AuthContext } from "../../contexts/AuthContext";
import { getOrdersFromCustomer } from "../../services/OrderService";

const Orders = () => {
    const [orders, setOrders] = useState<Order[]>([]);
    const { customer } = useContext(AuthContext);

    useEffect(() => {
        if (customer !== null) {
            getOrdersFromCustomer(customer.email).then((data: Order[]) => {
                setOrders(data);
            });
        }
    }, [customer]);

    return (
        <div>
            <h1>Bestillinger</h1>
            <div className="row">
                {
                    orders.map((order, index) => {
                        return (
                            <div className="col-12 col-md-6 col-lg-4" key={index}>
                                <div className="card m-1">
                                    <div className="card-body">
                                        <h5 className="card-title">Ordre ID: {order.id}</h5>
                                        <p className="card-text">Dato: {order.date.toDateString()}</p>
                                        <p className="card-text">Tidspunkt: {order.time}</p>
                                        <p className="card-text">Pris: {order.totalPrice} (uden rabat)</p>
                                        <p className="card-text">Rabat: {order.discount}%</p>
                                    </div>
                                </div>
                            </div>
                        )
                    })
                }
            </div>
        </div>
    )
}

export default Orders