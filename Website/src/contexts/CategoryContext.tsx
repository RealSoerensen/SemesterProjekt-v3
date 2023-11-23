import React, { createContext, useContext, useState, ReactNode } from 'react';
import Category from '../models/Category';
import { CustomCard } from '../components/Card/Card';
import bats from '../content/images/bat.jpg';
import balls from '../content/images/Balls.jpg';
import shoes from '../content/images/shoes.jpg';
import clothes from '../content/images/shirt.jpg';
import bags from '../content/images/bag.jpg';


// Creating the CategoryContext
const CategoryContext = createContext<{
    categories: CustomCard[];
    setCategories: React.Dispatch<React.SetStateAction<CustomCard[]>>;
} | undefined>(undefined);

interface CategoryProviderProps {
    children: ReactNode;
}

export const CategoryProvider: React.FC<CategoryProviderProps> = ({ children }) => {
    const [categories, setCategories] = useState<CustomCard[]>([
        { image: bats, title: 'Bat', cardDescription: 'Vælg fra en bred vifte af bat', linkto: '/category/' + Category.Bats },
        { image: balls, title: 'Bolde', cardDescription: 'Bolde til padel og strandtennis', linkto: '/category/' + Category.Balls },
        { image: shoes, title: 'Sko', cardDescription: 'Sko til padel og strandtennis', linkto: '/category/' + Category.Shoes },
        { image: clothes, title: 'Tøj', cardDescription: 'Tøj til padel og strandtennis', linkto: '/category/' + Category.Clothes },
        { image: bags, title: 'Tasker', cardDescription: 'Taske til padel og strandtennis', linkto: '/category/' + Category.Bags }
    ]);
    return (
        <CategoryContext.Provider value={{ categories, setCategories }}>
            {children}
        </CategoryContext.Provider>
    );
};

export const useCategory = () => {
    const context = useContext(CategoryContext);
    if (!context) {
        throw new Error('useCategory must be used within a CategoryProvider');
    }
    return context;
};
