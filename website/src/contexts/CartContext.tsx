import { Dispatch, SetStateAction, ReactNode, createContext, FC, useState, useEffect } from "react";
import Product from "../models/Product";

interface CartContextType {
    cart: Product[];
    setCart: Dispatch<SetStateAction<Product[]>>;
}

interface CartProviderProps {
    children: ReactNode;
}

export const CartContext = createContext<CartContextType>({
    cart: [],
    setCart: () => { },
});

export const CartProvider: FC<CartProviderProps> = ({ children }) => {
    const [cart, setCart] = useState<Product[]>(() => {
        const cartString = localStorage.getItem('cart');
        if (cartString) {
            const cart: Product[] = JSON.parse(cartString);
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