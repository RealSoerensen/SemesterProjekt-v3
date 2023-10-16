import React from 'react';
import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';


//images
import frontpageImage from '../content/images/frontpageImage.jpg';
import bats from '../content/images/bat.jpg';
import balls from '../content/images/Balls.jpg';
import shoes from '../content/images/shoes.jpg';
import clothes from '../content/images/shirt.jpg';
import bags from '../content/images/bag.jpg';
import CustomCard from '../models/CustomCard';
import Card from '../components/Card/Card';

const HomePage: React.FC = () => {

    const [categories] = useState<CustomCard[]>([
        new CustomCard(bats, 'Bats', "Choose from a wide range of padel bats"),
        new CustomCard(balls, 'Balls', "Balls for padel and beach tennis"),
        new CustomCard(shoes, 'Shoes', "Shoes for padel and beach tennis"),
        new CustomCard(clothes, 'Clothes', " Clothes for padel and beach tennis"),
        new CustomCard(bags, 'Bags', " Bags for padel and beach tennis")
    ]);
    const [shuffledCategories, setShuffledCategories] = useState<CustomCard[]>([]);

    useEffect(() => {
        const shuffled = [...categories].sort(() => Math.random() - 0.5);
        if (shuffled.length > 4) {
            shuffled.pop();
        }
        setShuffledCategories(shuffled);
    }, [categories]);

    return (
        <div className='mb-5'>
            <div className='overflow-hidden position-relative text-center'>
                <img className="img-fluid object-fit-cover" style={{ width: "100%", height: "500px" }} src={frontpageImage} alt='frontpage' />

                <div className='position-absolute' style={{ top: "50%", left: "50%", transform: "translate(-50%, -50%)" }}>
                    <h2 className='text-white'>
                        Padel Shop
                    </h2>
                    <Link to="" className='btn btn-primary'>
                        SHOP NU
                    </Link>
                </div>
            </div>
            <div className='row mt-4'>
                <Card cards={shuffledCategories} />
            </div>
            <div className='row mt-5'>
                <h2 className='text-center'>
                    Best sellers
                </h2>
                {/* <Card cards={categories} /> */}
            </div>
        </div>
    );
};

export default HomePage;
