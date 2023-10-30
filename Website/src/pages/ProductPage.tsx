import { useParams } from "react-router-dom";
import Product from "../models/Product";
import { useEffect, useState } from "react";
import { getProductById } from "../services/ProductService";


const ProductPage = () => {
    const { id } = useParams<{ id: string }>();
    const [product, setProduct] = useState<Product | null>(null);

    useEffect(() => {
        if (id) {
            getProductById(parseInt(id)).then((product) => setProduct(product));
        }
    }, [id]);



    return (
        <div>
            Produkt side
            <br />
            Product id: {id}
            <br />
            Produkt navn: {product?.name}
            <br />
            Produkt beskrivelse: {product?.description}
            <br />
            Produkt billede: {product?.image}
            <br />
            Produkt kategori: {product?.category}
            <br />
            Produkt brand: {product?.brand}
        </div>
    )
}

export default ProductPage