class Orderline {
    orderID: number;
    productID: number;
    quantity: number;
    priceAtTimeOfOrder: number;
    constructor(orderID: number, productID: number, quantity: number, priceAtTimeOfOrder: number) {
        this.orderID = orderID;
        this.productID = productID;
        this.quantity = quantity;
        this.priceAtTimeOfOrder = priceAtTimeOfOrder;
    }
}

export default Orderline;