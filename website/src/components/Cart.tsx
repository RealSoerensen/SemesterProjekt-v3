import { useContext } from "react";
import { Link } from "react-router-dom";
import { CartContext, CartItem } from "../contexts/CartContext";
import Image from "./Image";

type Props = {
    HideClass: string;
}

const Cart: React.FC<Props> = (props) => {
    const { cart } = useContext(CartContext);

    const calculateTotal = () => {
        let total = 0;
        cart.forEach((item: CartItem) => {
            total += item.productDescription.price;
        });
        return total;
    }

    return (
        <div className={`dropdown m-1 d-inline ${props.HideClass}`}>
            <button className="btn btn-primary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                Kurv <span className="badge bg-secondary">{cart.length}</span>
            </button>
            <ul className="dropdown-menu" style={{ width: 300, translate: '-50%', }}>
                {
                    cart.length === 0 ? <li className="dropdown-item">Kurven er tom</li> :
                        cart.map((item: CartItem, index: number) => {
                            return (
                                <li className="dropdown-item" key={index}>
                                    <div className="row">
                                        <div className="col-5 p-1">
                                            <Image image={item.productDescription.image} imageTitle={item.productDescription.name} className="img-fluid" />
                                        </div>
                                        <div className="col-5 p-1">
                                            <p className="fw-bold">{item.productDescription.name}</p>
                                            <p className="fw-bold">{item.productDescription.price} kr.</p>
                                        </div>
                                        <div className="col-2 p-1 text-center">
                                            <button className="btn btn-danger">
                                                X
                                            </button>
                                        </div>
                                    </div>
                                </li>
                            )
                        })
                }
                <div className="container">
                    <hr />
                    <div className="row">
                        <div className="col-6">
                            <p className="fw-bold">Total:</p>
                        </div>
                        <div className="col-6">
                            <p className="fw-bold">{calculateTotal()} kr.</p>
                        </div>
                        <Link to="/cart">
                            <button className="btn btn-primary" type="button">
                                Gå til kurv
                            </button>
                        </Link>
                    </div>
                </div>
            </ul>
        </div >
    )
}

export default Cart;
