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
    const [sliceNum, setSliceNum] = useState(4)
    const [buttonText, setButtonText] = useState('')
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
    useEffect(()=>{
        if(relatedProducts.length>4){
            setButtonText('Vis Flere')
        }
    },[relatedProducts])
    const showmore = () => {
        if(relatedProducts.length >sliceNum){
            setSliceNum(sliceNum+4)
        }
        if(relatedProducts.length+4 >sliceNum){
            setButtonText('Vis Færre')
        }
        if(buttonText=="Vis Færre"){
            setSliceNum(4)
            setButtonText('Vis Flere')
        }
    }

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
                                        <button className="btn btn-primary mx-auto " onClick={() => addItem(product, cart, setCart)}>Tilføj til kurv</button>
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
                                ( <>
                                {
                                    relatedProducts.slice(0,sliceNum).map((product, index) => {
                                        return (
                                            <div className="col-sm-6 col-md-3 mb-4" key={index}>
                                                <ProductShowcase key={index} product={product} />
                                            </div>
                                        )
                                    })}
                                    {
                                        relatedProducts.length >4 ? (
                                        <div className="col-12 d-flex justify-content-center">
                                            <button onClick={showmore} className="btn btn-primary mx-auto mt-4" style={{width:100}}>{buttonText}</button>
                                        </div> ): 
                                        (<></>)
                                    }
                                    </>
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