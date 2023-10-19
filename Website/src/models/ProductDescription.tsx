class ProductDescription {
    id: number;
    description: string;
    price: number;
    name: string;
    image: string;
    stock: number;
    brand: string;
    category: string;

    constructor(id: number, description: string, price: number, name: string, image: string, stock: number, brand: string, category: string) {
        this.id = id;
        this.description = description;
        this.price = price;
        this.name = name;
        this.image = image;
        this.stock = stock;
        this.brand = brand;
        this.category = category;
    }
}

export default ProductDescription;