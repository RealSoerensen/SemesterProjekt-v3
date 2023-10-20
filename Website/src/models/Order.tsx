class Order {
    id: number;
    date: Date;
    time: string;
    customerEmail: string;
    discount: number;

    constructor(id: number, date: string, time: string, customerEmail: string, discount: number) {
        this.id = id;
        this.date = new Date(date);
        this.time = time;
        this.customerEmail = customerEmail;
        this.discount = discount;
    }
}

export default Order;