class Orderline {
    orderID: number;
    productID: number;
    quantity: number;

    constructor(orderID: number, productID: number, quantity: number) {
        this.orderID = orderID;
        this.productID = productID;
        this.quantity = quantity;
    }
}

export default Orderline;