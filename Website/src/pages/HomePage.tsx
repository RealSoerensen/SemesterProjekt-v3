import React from 'react';
import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getAllProducts } from '../services/ProductService';
import { CustomCard } from '../components/Card/Card';
import Card from '../components/Card/Card';
import Product from '../models/Product';
import Category from '../models/Category';
import ProductShowcase from '../components/ProductShowcase';

//images
import frontpageImage from '../content/images/frontpageImage.jpg';
import bats from '../content/images/bat.jpg';
import balls from '../content/images/Balls.jpg';
import shoes from '../content/images/shoes.jpg';
import clothes from '../content/images/shirt.jpg';
import bags from '../content/images/bag.jpg';
import LoadingSpinner from '../components/Spinner';

const HomePage: React.FC = () => {

    const [categories] = useState<CustomCard[]>([
        new CustomCard(bats, 'Bat', "Vælg fra en bred vifte af bat", "category/" + Category.Bats),
        new CustomCard(balls, 'Bolde', "Bolde til padel og strandtennis", "category/" + Category.Balls),
        new CustomCard(shoes, 'Sko', "Sko til padel og strandtennis", "category/" + Category.Shoes),
        new CustomCard(clothes, 'Tøj', "Tøj til padel og strandtennis", "category/" + Category.Clothes),
        new CustomCard(bags, 'Tasker', "Taske til padel og strandtennis", "category/" + Category.Bags)
    ]);
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
        getAllProducts()?.then((data) => setProducts(data));
        setIsLoading(false);
    }, []);

    useEffect(() => {
        if (products?.length > 0) {
            setBestSellers(products)
        }
    }, [products]);

    useEffect(() => {
        setIsLoading(true);
        if (products?.length !== bestSellers?.length) {
            return;
        }
        const shuffled = [...bestSellers].sort(() => Math.random() - 0.5);
        const selectedItems = shuffled.slice(0, 4);
        if (selectedItems.length > 4) {
            selectedItems.pop();
        }
        setShuffledBestSellers([])
        for (let i = 0; i < selectedItems.length; i++) {
            setShuffledBestSellers((prev) => [...prev, selectedItems[i]]);
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
