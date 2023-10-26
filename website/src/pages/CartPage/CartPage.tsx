import { useContext } from 'react';
import './CartPage.css';
import { CartContext, CartItem } from '../../contexts/CartContext';
import Image from '../../components/Image';
import { getProductById } from '../../services/ProductService';
import { getProductDescriptionById } from '../../services/ProductDescription';

const CartPage = () => {
    const { cart, setCart } = useContext(CartContext)

    const removeItem = (index: number) => {
        const newCart = cart.filter((_: CartItem, i: number) => i !== index);
        setCart(newCart);
    }

    const calculateTotal = () => {
        let total = 0;
        cart.forEach((item: CartItem) => {
            total += item.product.salePrice;
        });
        return total;
    }

    const addItem = () => {
        for (let i = 1; i < 10; i++) {
            getProductById(i).then((product) => {
                if (!product) return;
                console.log(product);
                // getProductDescriptionById(product.productDescriptionID).then((productDescription) => {
                //     if (!productDescription) return;
                //     const newCartItem = new CartItem(product, productDescription);
                //     setCart([...cart, newCartItem]);
                // });
            }
            );
        }
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
                        cart.length === 0 ? <p>Din kurv er tom</p> :
                            <table className="table">
                                <thead>
                                    <tr>
                                        <th>Product</th>
                                        <th>Price</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        cart.map((item: CartItem, index: number) => {
                                            return (
                                                <tr key={index}>
                                                    <td>
                                                        <Image image={item.product.image} imageTitle={item.product.productName} className="cart-item-image" />
                                                        <span>{item.product.productName}</span>
                                                    </td>
                                                    <td>{item.product.salePrice} kr</td>
                                                    <td>
                                                        <button className="btn btn-danger" onClick={() => removeItem(index)}>X</button>
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
                            <h4>Total: {calculateTotal()}kr</h4>
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-md-12">
                            <button className='btn btn-primary m-1'>Gå til betaling</button>
                        </div>
                        <div className="col-md-12">
                            <button className='btn btn-secondary m-1' onClick={addItem}>Tilføj flere produkter</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default CartPage;