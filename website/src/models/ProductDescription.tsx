class ProductDescription {
    id: number;
    description: string;
    price: number;
    name: string;
    image: string;
    stock: number;

    constructor(id: number, description: string, price: number, name: string, image: string, stock: number) {
        this.id = id;
        this.description = description;
        this.price = price;
        this.name = name;
        this.image = image;
        this.stock = stock;
    }
}

export default ProductDescription;