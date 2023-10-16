import React from "react";
import { useParams } from "react-router-dom";

const Category: React.FC = () => {
    const { category } = useParams<{ category: string }>();

    return (
        <div>
            <h1>Category</h1>
            <p>See products from {category} here!</p>
        </div>
    );
};

export default Category;