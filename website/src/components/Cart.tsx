import { useContext, useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { CartContext } from "../contexts/CartContext";
import Product from "../models/Product";
import ProductDescription from "../models/ProductDescription";
import { getProductDescriptionById } from "../services/ProductDescription";


class CartItem {
    product: Product;
    productDescription: ProductDescription;

    constructor(product: Product, productDescription: ProductDescription) {
        this.product = product;
        this.productDescription = productDescription;
    }
}

const Cart: React.FC = () => {
    const { cart } = useContext(CartContext);
    const [cartItems, setCartItems] = useState<CartItem[]>([]);

    useEffect(() => {
        cart.forEach(product => {
            getProductDescriptionById(product.productDescriptionID).then((data) => {
                if (data !== null)
                    setCartItems(prev => [...prev, new CartItem(product, data)]);
            });
        });

    }, [cart]);

    return (
        <div className='dropdown m-1'>
            <button className="btn btn-primary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                Kurv <span className="badge bg-secondary">{cart.length}</span>
            </button>
            <ul className="dropdown-menu">
                {
                    cartItems.length === 0 ? <li className='dropdown-item'>Kurven er tom</li> :
                        cartItems.map((item, index) => {
                            return (
                                <li className='dropdown-item' key={index}>
                                    <div className='row'>
                                        <div className='col-3'>
                                            <img className='img-fluid' src={item.productDescription.image} alt='product' />
                                        </div>
                                        <div className='col-9'>
                                            <h6>{item.productDescription.name}</h6>
                                            <p>Price: {item.productDescription.price}</p>
                                        </div>
                                    </div>
                                </li>
                            )
                        })



                }
                <div className="container">
                    <Link to="/cart">
                        <button className="btn btn-primary" type="button">
                            Gå til kurv
                        </button>
                    </Link>
                </div>
            </ul>
        </div >
    )
}

export default Cart;
