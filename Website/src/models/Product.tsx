class Product {
    description: string;
    id: number;
    image: string;
    category: string;
    name: string;
    stock: number;
    salePrice: number;
    purchasePrice: number;
    normalPrice: number;
    brand: string;

    constructor(description: string, id: number, image: string, category: string, name: string, stock: number, salePrice: number, purchasePrice: number, normalPrice: number, brand: string) {
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