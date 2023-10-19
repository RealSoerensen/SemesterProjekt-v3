import React, { useContext } from "react";
import { CartContext, CartItem } from "../contexts/CartContext";
import { getProductDescriptionById } from "../services/ProductDescription";
import { getProductById } from "../services/ProductService";
import Image from "../components/Image";


const Cart: React.FC = () => {
    const { cart, setCart } = useContext(CartContext)

    const addToCart = () => {
        getProductById(1).then((data) => {
            if (data === null) return;
            getProductDescriptionById(data.productDescriptionID).then((productDescription) => {
                if (productDescription === null) return;
                const newCartItem = new CartItem(data, productDescription);
                console.log("logging newCartItem");
                setCart([...cart, newCartItem]);
                console.log("logged cart");
            });
        }
        );
    }

    return (
        <div>
            <button onClick={addToCart}>Add to cart</button>
            <h1>Kurven</h1>
            <div>
                <label>
                    Se alle produkter i kurven her:
                </label>
                {
                    cart.length === 0 ? <p>Kurven er tom</p> :
                        cart.map((item: CartItem, index: number) => {
                            console.log("logging item: " + item);
                            return (
                                <div key={index}>
                                    <p>{item.productDescription.name}</p>
                                    <Image image={item.productDescription.image} imageTitle={item.productDescription.name} className="" />
                                    <p>{item.productDescription.price} kr.</p>
                                </div>
                            )
                        })
                }
            </div>
        </div>
    );
};

export default Cart;