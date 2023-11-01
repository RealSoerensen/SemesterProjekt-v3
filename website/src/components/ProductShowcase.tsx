import { Link } from "react-router-dom";
import Product from "../models/Product";
import Image from "./Image";
import { useContext } from "react";
import { CartContext } from "../contexts/CartContext";
import { addItem, calculateProcentDifference } from "../utils/CartUtil";

const ProductShowcase: React.FC<{ product: Product }> = ({ product }) => {
    const { cart, setCart } = useContext(CartContext);

    return (
        <div className="card" style={{ width: "18rem" }}>
            <div className="card-body d-flex flex-column">
                <Link to={`/product/${product.id}`} className="text-decoration-none text-dark">
                    <Image image={product.image} imageTitle={product.name} className="img-fluid" />
                    <div className="card-body">
                        <h5 className="card-title">{product.name}</h5>
                        <p className="card-text">{product.brand}</p>
                        {
                            product.salePrice === product.normalPrice ?
                                <p className="card-text">{product.salePrice} kr.</p> :
                                <div>
                                    <p className="card-text"><del>{product.normalPrice} kr.</del> {product.salePrice} kr.</p>
                                    <p className="card-text">Du sparer {calculateProcentDifference(product)}%</p>
                                </div>
                        }


                    </div>
                </Link>
            </div>
            <div className="container text-center mb-2 mt-auto">
                <Link to={`/product/${product.id}`} className="btn btn-primary btn-block m-1">Se produkt</Link>
                <button className="btn btn-primary btn-block m-1" onClick={() => addItem(product, cart, setCart)}>Tilføj til kurv</button>
            </div>
        </div>
    );
};

export default ProductShowcase;