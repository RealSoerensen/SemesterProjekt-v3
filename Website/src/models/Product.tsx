class Product {
    desciption: string;
    productID: number;
    image: string;
    category: string;
    productName: string;
    stock: number;
    salePrice: number;
    purchasePrice: number;
    normalPrice: number;
    brand: string;

    constructor(desciption: string, productID: number, image: string, category: string, productName: string, stock: number, salePrice: number, purchasePrice: number, normalPrice: number, brand: string) {
        this.desciption = desciption;
        this.productID = productID;
        this.image = image;
        this.category = category;
        this.productName = productName;
        this.stock = stock;
        this.salePrice = salePrice;
        this.purchasePrice = purchasePrice;
        this.normalPrice = normalPrice;
        this.brand = brand;
    }
}

export default Product;