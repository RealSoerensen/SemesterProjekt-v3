class ProductDescription {
    id: number;
    description: string;
    price: number;
    name: string;
    image: string;
    stock: number;
    brand: string;

    constructor(id: number, description: string, price: number, name: string, image: string, stock: number, brand: string) {
        this.id = id;
        this.description = description;
        this.price = price;
        this.name = name;
        this.image = image;
        this.stock = stock;
        this.brand = brand;
    }
}

export default ProductDescription;