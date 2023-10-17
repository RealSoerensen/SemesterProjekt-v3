class Order {
    id: number;
    date: Date;
    time: string;
    customerEmail: string;
    totalPrice: number;
    discount: number;

    constructor(id: number, date: string, time: string, customerEmail: string, totalPrice: number, discount: number) {
        this.id = id;
        this.date = new Date(date);
        this.time = time;
        this.customerEmail = customerEmail;
        this.totalPrice = totalPrice;
        this.discount = discount;
    }
}

export default Order;