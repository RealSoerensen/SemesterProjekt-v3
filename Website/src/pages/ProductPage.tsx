import { useParams } from "react-router-dom";
import Product from "../models/Product";
import { useEffect, useState } from "react";
import { getProductById, getProductsByCategory } from "../services/ProductService";
import Image from "../components/Image";
import ProductShowcase from "../components/ProductShowcase";
import { useContext } from "react";
import { CartContext } from "../contexts/CartContext";
import { addItem, calculateProcentDifference } from "../utils/CartUtil";
import LoadingSpinner from "../components/Spinner";


const ProductPage = () => {
    const { id } = useParams<{ id: string }>();
    const [product, setProduct] = useState<Product | null>(null);
    const [relatedProducts, setRelatedProducts] = useState<Product[]>([]);
    const { cart, setCart } = useContext(CartContext);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        setIsLoading(true);
        if (id) {
            getProductById(parseInt(id)).then((product) => setProduct(product));
            setIsLoading(false);
        }
    }, [id]);

    useEffect(() => {
        setIsLoading(true);
        if (product?.category) {
            getProductsByCategory(product.category)
                .then((products) => {
                    const updatedProducts = products.filter((p: Product) => p.id !== product.id && !p.inactive);
                    setRelatedProducts(updatedProducts);
                });
            setIsLoading(false);
        }
    }, [product]);

    if (isLoading) return (<div className="container"><LoadingSpinner /></div>)

    if (!product) return (<div>Produktet findes ikke</div>)

    return (
        <div className="container">
            <div className="row mt-5">
                <div className="col-md-6 col-sm-3">
                    <Image image={product.image} imageTitle={product.name} className="img-fluid" />
                </div>
                <div className="col-4">
                    <h1>{product.name}</h1>
                    <p>{product.brand}</p>
                    <p>{product.description}</p>
                </div>
                <div className="col-md-2 col-sm-6">
                    <div className="border rounded p-3">
                        {
                            product.inactive ? <p>Produktet er udløbet</p> : (
                                product.salePrice === product.normalPrice ? (
                                    <div>
                                        <p className="">{product.salePrice} kr.</p>
                                        <button className="btn btn-primary mx-auto" onClick={() => addItem(product, cart, setCart)}>Tilføj til kurv</button>
                                    </div>
                                ) : (
                                    <div className="mb-2">
                                        <p className=""><del>{product.normalPrice} kr.</del> {product.salePrice} kr.</p>
                                        <p className="">Du sparer {calculateProcentDifference(product)}%</p>
                                        <button className="btn btn-primary mx-auto" onClick={() => addItem(product, cart, setCart)}>Tilføj til kurv</button>
                                    </div>
                                )
                            )
                        }
                    </div>
                </div>
                <div className="col-12 mt-5">
                    <h2>Relaterede produkter</h2>
                    <div className="row">
                        {
                            relatedProducts.length > 0 ?
                                (
                                    relatedProducts.map((product, index) => {
                                        return (
                                            <div className="col-sm-6 col-md-4 col-xl-3 d-flex justify-content-center m-1" key={index}>
                                                <ProductShowcase key={index} product={product} />
                                            </div>
                                        )
                                    })
                                ) : (
                                    <p>Der er ingen relaterede produkter</p>
                                )
                        }
                    </div>
                </div>
                <div className="col-12 mt-5">
                    <h2>Reviews</h2>
                </div>
            </div>
        </div>
    )
}

export default ProductPage