import { useParams } from "react-router-dom";
import Product from "../models/Product";
import { useEffect, useState } from "react";
import { getAllProducts, getProductById, getProductsByCategory } from "../services/ProductService";
import Image from "../components/Image";
import Card from "../components/Card/Card";
import ProductShowcase from "../components/ProductShowcase";
import { useContext } from "react";
import { CartContext, CartItem } from "../contexts/CartContext";
import Orderline from "../models/Orderline";


const ProductPage = () => {
    const { id } = useParams<{ id: string }>();
    const [product, setProduct] = useState<Product | null>(null);
    const [relatedProducts, setRelatedProducts] = useState<Product[]>([]);
    const { cart, setCart } = useContext(CartContext);


    useEffect(() => {
        if (id) {
            getProductById(parseInt(id)).then((product) => setProduct(product));
        }
    }, [id]);
    useEffect(() => {
        if (product?.category)
            getProductsByCategory(product?.category).then((products) => setRelatedProducts(products));
    }, [product])


    useEffect(() => {
        for (let i = 0; i < relatedProducts.length; i++) {
            if (relatedProducts[i].id === product?.id) {
                const updatedArray = relatedProducts.filter((product) => product.id !== relatedProducts[i].id);
                setRelatedProducts(updatedArray);
            }
        }
    }, [relatedProducts])
    if (!product) return (<div>Produktet findes ikke</div>)


    const addToCart = (product: Product) => {
        if (!cart.some(item => item.product.id === product.id)) {
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
        <div className="container">
            <div className="row mt-5">
                <div className="col-6">
                    <Image image={product?.image} imageTitle={product?.name} className="img-fluid" />
                </div>
                <div className="col-4">
                    <h1>{product?.name}</h1>
                    <p>Brand: {product?.brand}</p>
                    <p>{product?.description}</p>
                </div>
                <div className="col-2">
                    <div className="border rounded p-3">
                        {
                            product.salePrice === product.normalPrice ? <p className="">{product.salePrice} kr.</p> :
                                <div className="mb-2">
                                    <p className=""><del>{product.normalPrice} kr.</del> {product.salePrice} kr.</p>
                                    <p className="">Du sparer {calculateProcentDifference()}%</p>
                                </div>
                        }
                        <button className="btn btn-primary mx-auto" onClick={() => (addToCart)}>Add To Cart</button>
                    </div>

                </div>
                <div className="col-12 m-5">
                    <h2>Relaterede produkter</h2>
                    {
                        relatedProducts?.length > 0 ?
                            <>{
                                relatedProducts.map((product, index) => {
                                    return (
                                        <ProductShowcase key={index} product={product} />
                                    )
                                })
                            }</> : <p>Der er ingen relaterede produkter</p>
                    }

                </div>
                <div className="col-12 m-5">
                    <h2>Reviews</h2>
                </div>
            </div>
        </div>
    )
}

export default ProductPage