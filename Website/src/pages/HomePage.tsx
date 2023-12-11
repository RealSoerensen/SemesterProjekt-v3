import React from 'react';
import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getAllProducts } from '../services/ProductService';
import { CustomCard } from '../components/Card/Card';
import Card from '../components/Card/Card';
import Product from '../models/Product';
import ProductShowcase from '../components/ProductShowcase';

//images
import frontpageImage from '../content/images/frontpageImage.jpg';
import LoadingSpinner from '../components/Spinner';
import { useCategory } from '../contexts/CategoryContext';

const HomePage: React.FC = () => {
    const { categories } = useCategory();

    const [shuffledCategories, setShuffledCategories] = useState<CustomCard[]>([]);
    const [products, setProducts] = useState<Product[]>([]);
    const [bestSellers, setBestSellers] = useState<Product[]>([]);
    const [shuffledBestSellers, setShuffledBestSellers] = useState<Product[]>([]);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        const shuffled = [...categories].sort(() => Math.random() - 0.5);
        if (shuffled.length > 4) {
            shuffled.pop();
        }
        setShuffledCategories(shuffled);
    }, [categories]);

    useEffect(() => {
        setIsLoading(true);
        getAllProducts()?.then((data) => {
            if (data) {
                setProducts(data);
            }
        });
        setIsLoading(false);
    }, []);

    useEffect(() => {
        if (products?.length > 0) {
            const noInactiveProducts = products.filter((product) => !product.inactive);
            setBestSellers(noInactiveProducts)
        }
    }, [products]);

    useEffect(() => {
        setIsLoading(true);
        if (bestSellers?.length > 0) {
            let shuffled = [...bestSellers].sort(() => Math.random() - 0.5);
            shuffled = shuffled.slice(0, 4);
            setShuffledBestSellers(shuffled);
        }
        setIsLoading(false);
    }, [products, bestSellers])

    return (
        <div className='container'>
            <div className='overflow-hidden position-relative text-center'>
                <img className="img-fluid object-fit-cover" style={{ width: "100%", height: "500px" }} src={frontpageImage} alt='frontpage' />
                <div className='position-absolute' style={{ top: "50%", left: "50%", transform: "translate(-50%, -50%)" }}>
                    <h2 className='text-white'>
                        Padel Shop
                    </h2>
                    <Link to="/" className='btn btn-primary'>
                        SHOP NU
                    </Link>
                </div>
            </div>
            <div className='row mt-4'>
                <Card cards={shuffledCategories} />
            </div>
            <div className='row mt-5'>
                <h2 className='text-center'>
                    Fremhævede produkter
                </h2>
                {
                    isLoading ? (
                        <LoadingSpinner />
                    ) : shuffledBestSellers.map((product, index) => (
                        <div className='col-lg-3 col-sm-6 col-md-3  d-flex justify-center mb-5' key={index}>
                            <ProductShowcase product={product} />
                        </div>
                    ))
                }

            </div>
        </div>
    );
};

export default HomePage;
