import { CartItem } from "../contexts/CartContext";
import Orderline from "../models/Orderline";
import Product from "../models/Product";


export const addItem = (product: Product, cart: CartItem[], setCart: React.Dispatch<React.SetStateAction<CartItem[]>>) => {
    // if product already exists in cart, then update quantity
    const existingCartItem = cart.find((item: CartItem) => item.product.id === product.id);

    if (existingCartItem) {
        const newCart = [...cart];
        const index = newCart.findIndex((cartItem: CartItem) => cartItem.product.id === product.id);

        if (index >= 0) {
            newCart[index].orderline.quantity += 1;
            setCart(newCart);
        }
    } else {
        const orderline = new Orderline(1, product.id, 1, product.salePrice);
        const cartItem = new CartItem(product, orderline);
        setCart([...cart, cartItem]);
    }
};

export const removeItem = (productID: number, cart: CartItem[], setCart: React.Dispatch<React.SetStateAction<CartItem[]>>) => {
    const newCart = cart.filter((item: CartItem) => item.orderline.productID !== productID);
    setCart(newCart);
}

export const calculateTotal = (cart: CartItem[]) => {
    let total = 0;
    cart.forEach((item: CartItem) => {
        total += item.product.salePrice * item.orderline.quantity;
    });
    return Math.round(total * 100) / 100;
}

export const calculateProcentDifference = (product: Product) => {
    const procentDifference = Math.round((product.normalPrice - product.salePrice) / product.normalPrice * 100);
    return procentDifference;
}
