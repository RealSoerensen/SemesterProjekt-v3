import React from "react";
import { useParams } from "react-router-dom";

const CategoryPage: React.FC = () => {
    const { category } = useParams<{ category: string }>();

    return (
        <div>
            <h1>Kategori</h1>
            <p>Se alle produkter fra {category} her!</p>
        </div>
    );
};

export default CategoryPage;