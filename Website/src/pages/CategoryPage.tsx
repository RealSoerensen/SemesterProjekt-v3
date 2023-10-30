import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getProductsByCategory } from "../services/ProductService";
import Product from "../models/Product";
import ProductShowcase from "../components/ProductShowcase";

const CategoryPage: React.FC = () => {
    const { category } = useParams<{ category: string }>();
    const [products, setProducts] = useState<Product[]>([]);

    useEffect(() => {
        if (category) {
            const categoryId = parseInt(category);
            getProductsByCategory(categoryId).then((products) => setProducts(products));
        }
    }, [category]);

    if (products.length === 0) {
        return (
            <div>
                <h1>Kategori</h1>
                <p>Der er ingen produkter i denne kategori</p>
            </div>
        );
    }

    const categoryString = category === "0" ? "Bats" : category === "1" ? "Sko" : category === "2" ? "Bolde" : category === "3" ? "Tøj" : category === "4" ? "Tasker" : category === "5" ? "Tilbehør" : "Ukendt";

    return (
        <div className="container-fluid">
            <h1>{categoryString}</h1>
            <p>Se alle produkter fra {categoryString} her!</p>
            <div className="row">
                {products.map((product) => (
                    <div className="col-sm-6 col-md-3 col-xl-2 d-flex justify-content-center m-1" key={product.id}>
                        <ProductShowcase product={product} />
                    </div>
                ))}
            </div>
        </div>
    );
};

export default CategoryPage;