import { Link } from "react-router-dom";
import Product from "../models/Product";
import Image from "./Image";
import { useContext } from "react";
import { CartContext, CartItem } from "../contexts/CartContext";
import Orderline from "../models/Orderline";


const ProductShowcase: React.FC<{ product: Product }> = ({ product }) => {
    const { cart, setCart } = useContext(CartContext);

    const addToCart = (product: Product) => {
        // if product already exist in cart then update quantity
        const existingCartItem = cart.find((item: CartItem) => item.product.id === product.id);
        if (existingCartItem) {
            const newCart = [...cart];
            const index = newCart.findIndex((cartItem: CartItem) => cartItem.product.id === product.id);
            if (index >= 0) {
                newCart[index].orderline.quantity += 1;
                setCart(newCart);
            }
        }
        else {
            const orderline = new Orderline(1, product.id, 1, product.salePrice);
            const cartItem = new CartItem(product, orderline);
            setCart([...cart, cartItem]);
        }
    }

    const calculateProcentDifference = () => {
        const procentDifference = Math.round((product.normalPrice - product.salePrice) / product.normalPrice * 100);
        return procentDifference;
    }

    return (
        <div className="card" style={{ width: "18rem" }}>
            <Image image={product.image} imageTitle={product.name} className="img-fluid" />
            <div className="card-body">
                <h5 className="card-title">{product.name}</h5>
                <p className="card-text">{product.brand}</p>
                {
                    product.salePrice === product.normalPrice ? <p className="card-text">{product.salePrice} kr.</p> :
                        <div className="mb-2">
                            <p className="card-text"><del>{product.normalPrice} kr.</del> {product.salePrice} kr.</p>
                            <p className="card-text">Du sparer {calculateProcentDifference()}%</p>
                        </div>
                }

                <Link to={`/product/${product.id}`} className="btn btn-primary m-1">Se produkt</Link>
                <button className="btn btn-primary m-1" onClick={() => addToCart(product)}>Tilføj til kurv</button>
            </div>
        </div>
    );
};

export default ProductShowcase;