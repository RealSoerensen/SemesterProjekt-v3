import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getProductsByCategory } from "../services/ProductService";
import Product from "../models/Product";
import ProductShowcase from "../components/ProductShowcase";
import { categoryToString } from "../models/Category";

const CategoryPage: React.FC = () => {
    const { category } = useParams<{ category: string }>();
    const [products, setProducts] = useState<Product[]>([]);

    useEffect(() => {
        if (category) {
            const categoryId = parseInt(category);
            console.log(categoryId);
            getProductsByCategory(categoryId).then((products) => setProducts(products));
        }
    }, [category]);


    if (!category) {
        return (
            <div className="container"><h1>Ukendt kategori</h1></div>
        );
    }

    let categoryString = categoryToString(parseInt(category));

    return (
        <div className="container">
            <h1>{categoryString}</h1>
            <p>Se alle produkter fra {categoryString} her!</p>
            <div className="row">
                {products === null || products.length === 0 ?
                    <p>Der er ingen produkter i denne kategori</p>
                    :
                    products.map((product) => (
                        product.inactive ? null :
                            <div className="col-sm-6 col-md-4 col-xl-3 d-flex justify-content-center m-1" key={product.id}>
                                <ProductShowcase product={product} />
                            </div>
                    ))}
            </div>
        </div>
    );
};

export default CategoryPage;