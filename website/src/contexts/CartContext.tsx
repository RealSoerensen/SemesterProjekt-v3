import { Dispatch, SetStateAction, ReactNode, createContext, FC, useState, useEffect } from "react";
import Product from "../models/Product";
import Orderline from "../models/Orderline";

export class CartItem {
    product: Product;
    orderline: Orderline;

    constructor(product: Product, orderline: Orderline) {
        this.orderline = orderline;
        this.product = product;
    }
}

interface CartContextType {
    cart: CartItem[];
    setCart: Dispatch<SetStateAction<CartItem[]>>;
}

interface CartProviderProps {
    children: ReactNode;
}

export const calculateTotal = (cart: CartItem[]) => {
    let total = 0;
    cart.forEach((item: CartItem) => {
        total += item.product.salePrice * item.orderline.quantity;
    });
    return Math.round(total * 100) / 100;
}

export const CartContext = createContext<CartContextType>({
    cart: [],
    setCart: () => { },
});

export const CartProvider: FC<CartProviderProps> = ({ children }) => {
    const [cart, setCart] = useState<CartItem[]>(() => {
        const cartString = localStorage.getItem('cart');
        if (cartString) {
            const cart: CartItem[] = JSON.parse(cartString);
            return cart;
        }
        return [];
    });

    // Update the token in localStorage whenever it changes
    useEffect(() => {
        if (cart) {
            localStorage.setItem('cart', JSON.stringify(cart));
        } else {
            localStorage.removeItem('cart');
        }
    }, [cart]);

    return (
        <CartContext.Provider value={{ cart, setCart }}>
            {children}
        </CartContext.Provider>
    );
};