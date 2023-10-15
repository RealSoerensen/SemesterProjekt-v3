class Order {
    id: number;
    date: Date;
    customerEmail: string;
    totalPrice: number;
    discount: number;

    constructor(id: number, date: Date, customerEmail: string, totalPrice: number, discount: number) {
        this.id = id;
        this.date = date;
        this.customerEmail = customerEmail;
        this.totalPrice = totalPrice;
        this.discount = discount;
    }
}

export default Order;