import Category from "./Category";

class Product {
    description: string;
    id: number;
    image: string;
    name: string;
    stock: number;
    salePrice: number;
    purchasePrice: number;
    normalPrice: number;
    brand: string;
    category: Category;

    constructor(description: string, id: number, image: string, category: number, name: string, stock: number, salePrice: number, purchasePrice: number, normalPrice: number, brand: string) {
        this.description = description;
        this.id = id;
        this.image = image;
        this.category = category;
        this.name = name;
        this.stock = stock;
        this.salePrice = salePrice;
        this.purchasePrice = purchasePrice;
        this.normalPrice = normalPrice;
        this.brand = brand;
    }
}

export default Product;