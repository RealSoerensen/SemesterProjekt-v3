import { useContext } from "react";
import { Link } from "react-router-dom";
import { CartContext, CartItem, calculateTotal } from "../contexts/CartContext";
import Image from "./Image";

type Props = {
    HideClass: string;
}

const Cart: React.FC<Props> = (props) => {
    const { cart, setCart } = useContext(CartContext);

    const removeItem = (event: React.MouseEvent, item: CartItem) => {
        event.stopPropagation();
        const newCart = [...cart];
        const index = newCart.findIndex((cartItem: CartItem) => cartItem.product.id === item.product.id);
        if (index >= 0) {
            newCart.splice(index, 1);
            setCart(newCart);
        }
    }

    return (
        <div className={`dropdown m-1 d-inline ${props.HideClass}`}>
            <button className="btn btn-primary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                Kurv <span className="badge bg-secondary">{cart.length}</span>
            </button>
            <ul className="dropdown-menu" style={{ width: 400, translate: '-50%', }}>
                {
                    cart.length === 0 ? <li className="dropdown-item">Kurven er tom</li> :
                        cart.map((item: CartItem, index: number) => {
                            return (
                                <li className="dropdown-item" key={index}>
                                    <div className="row">
                                        <div className="col-3">
                                            <Link to={`/product/${item.product.id}`} className="text-decoration-none text-dark">
                                                <Image image={item.product.image} imageTitle={item.product.name} className="img-fluid" />
                                            </Link>
                                        </div>
                                        <div className="col-7 text-truncate">
                                            <Link to={`/product/${item.product.id}`} className="text-decoration-none text-dark">

                                                <p className="fw-bold">{item.product.name}</p>
                                                <p className="fw-bold">{item.orderline.quantity} x {item.product.salePrice} kr.</p>
                                            </Link>
                                        </div>
                                        <div className="col-2">
                                            <button className="btn btn-danger" onClick={(event) => removeItem(event, item)}>
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
                            <p className="fw-bold">{calculateTotal(cart)} kr.</p>
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
