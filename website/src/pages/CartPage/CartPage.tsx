import { useContext } from 'react';
import './CartPage.css';
import { CartContext, CartItem } from '../../contexts/CartContext';
import Image from '../../components/Image';
import { calculateTotal, addItem, removeItem } from '../../utils/CartUtil';
import { getProductById } from '../../services/ProductService';
import { Link } from 'react-router-dom';

const CartPage = () => {
    const { cart, setCart } = useContext(CartContext)

    const addItemToCart = () => {
        for (let i = 1; i < 9; i++) {
            getProductById(i).then((product) => {
                if (product) {
                    addItem(product, cart, setCart)
                }
            });
        }
    }

    const updateQuantity = (productID: number, value: string) => {
        const newCart = [...cart];
        const index = newCart.findIndex((cartItem: CartItem) => cartItem.orderline.productID === productID);
        const quantity = parseInt(value);
        if (quantity === 0) {
            newCart.splice(index, 1);
        }
        else {
            newCart[index].orderline.quantity = quantity;
        }
        setCart(newCart);
    }

    return (
        <div className="container">
            <div className="row">
                <div className="col-md-12">
                    <h1>Kurv</h1>
                </div>
            </div>
            <div className="row">
                <div className="col-md-12">
                    {
                        cart.length === 0 ?
                            <p>Din kurv er tom</p>
                            :
                            <table className="table">
                                <thead>
                                    <tr>
                                        <th>Produkt</th>
                                        <th>Salgspris</th>
                                        <th>Antal</th>
                                        <th>Total</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        cart.map((item: CartItem, index: number) => {
                                            return (
                                                <tr key={index}>
                                                    <td>
                                                        <Image image={item.product.image} imageTitle={item.product.name} className="cart-item-image" />
                                                        <span>{item.product.name}</span>
                                                    </td>
                                                    <td>{item.product.salePrice} kr</td>
                                                    <td>
                                                        <select onChange={(event) => updateQuantity(item.orderline.productID, event.target.value)} value={item.orderline.quantity}>
                                                            {
                                                                [...Array(10)].map((_, i) => {
                                                                    return (
                                                                        <option key={i}>{i}</option>
                                                                    )
                                                                })
                                                            }

                                                        </select>
                                                    </td>
                                                    <td>{Math.round(item.product.salePrice * item.orderline.quantity * 100) / 100} kr</td>
                                                    <td>
                                                        <button className="btn btn-danger" onClick={() => removeItem(item.orderline.productID, cart, setCart)}>X</button>
                                                    </td>
                                                </tr>
                                            )
                                        })
                                    }
                                </tbody>
                            </table>
                    }
                    <div className="row">
                        <div className="col-md-12">
                            <h4>Total: {calculateTotal(cart)}kr</h4>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-md-12">
                            <Link to="/checkout" className="btn btn-primary m-1">Gå til betaling</Link>
                        </div>
                        <div className="col-md-12">
                            <button className='btn btn-secondary m-1' onClick={addItemToCart}>Tilføj flere produkter</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default CartPage;