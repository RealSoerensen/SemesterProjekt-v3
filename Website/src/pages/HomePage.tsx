import React from 'react';
import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getAllProducts} from '../services/ProductService';

//images
import frontpageImage from '../content/images/frontpageImage.jpg';
import bats from '../content/images/bat.jpg';
import balls from '../content/images/Balls.jpg';
import shoes from '../content/images/shoes.jpg';
import clothes from '../content/images/shirt.jpg';
import bags from '../content/images/bag.jpg';
import { CustomCard } from '../components/Card/Card';
import Card from '../components/Card/Card';
import Product from '../models/Product';
import { getProductDescriptionById } from '../services/ProductDescription';
import ProductDescription from '../models/ProductDescription';

const HomePage: React.FC = () => {

    const [categories] = useState<CustomCard[]>([
        new CustomCard(bats, 'Bats', "Choose from a wide range of padel bats" , "category/bats"),
        new CustomCard(balls, 'Balls', "Balls for padel and beach tennis" , "category/balls"),
        new CustomCard(shoes, 'Shoes', "Shoes for padel and beach tennis", "category/shoes"),
        new CustomCard(clothes, 'Clothes', " Clothes for padel and beach tennis", "category/clothes"),
        new CustomCard(bags, 'Bags', " Bags for padel and beach tennis", "category/bags")
    ]);
    const [shuffledCategories, setShuffledCategories] = useState<CustomCard[]>([]);
    const [products, setProducts] = useState<Product[]>([]);
    const [bestSellers, setBestSellers] = useState<ProductDescription[]>([]);
    const [tempBestSellers, setTempBestSellers] = useState<ProductDescription[]>([]);
    const [shuffledBestSellers, setShuffledBestSellers] = useState<CustomCard[]>([]);
    const [base64image, setBase64image] = useState<string[]>([]);
    useEffect(() => {
        const shuffled = [...categories].sort(() => Math.random() - 0.5);
        if (shuffled.length > 4) {
            shuffled.pop();
        }
        setShuffledCategories(shuffled);
    }, [categories]);
    useEffect(() => {
        getAllProducts()?.then((data) => setProducts(data),);
    }, []);

    // useEffect(() => {
    //     if (products.length !== 0) {
    //         for(let i = 0; i < products.length; i++) {
    //             getAllProductDescriptionById(products[i].productDescriptionID).then((data) => {
    //                 setBestSellers((prev) => [...prev, data]);
    //         });};
    //     }
    // }, [products]);
    useEffect(() => {
        
        if (products?.length > 0) {
            const fetchedBestSellers: any[] | ((prevState: ProductDescription[]) => ProductDescription[]) = [];
            Promise.all(products.map(product => getProductDescriptionById(product.productDescriptionID)))
                .then(data => {
                    fetchedBestSellers.push(...data);
                    setBestSellers(fetchedBestSellers);
                });
        }
    }, [products]);
    useEffect(() => {
        if(products?.length == bestSellers?.length){
        const shuffled = [...bestSellers].sort(() => Math.random() - 0.5);
            const selectedItems = shuffled.slice(0, 4);
            console.log(selectedItems.length)
            if (selectedItems.length > 4) {
                selectedItems.pop();
            }
            setShuffledBestSellers([])
            for(let i = 0; i < selectedItems.length; i++) {
                setShuffledBestSellers((prev) => [...prev, new CustomCard(selectedItems[i].image, selectedItems[i].name, selectedItems[i].description, `product/${selectedItems[i].id}`)]);
            }
        }
        },[bestSellers])

    return (
        <div className='mb-5 container'>
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
                <Card cards={shuffledCategories}/>
            </div>
            <div className='row mt-5'>
                <h2 className='text-center'>
                    Highlighted Products
                </h2>
                {
                    shuffledBestSellers.length === 0 ? 
                    <div className="d-flex justify-content-center">
                        <div className="spinner-grow" role="status">
                            <span className="sr-only"></span>
                        </div>
                    </div>
                   :  <Card cards={shuffledBestSellers} />
                }
               
            </div>
        </div>
    );
};

export default HomePage;
