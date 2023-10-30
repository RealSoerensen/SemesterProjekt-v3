class Order {
    id: number;
    date: Date;
    time: string;
    customerEmail: string;


    constructor(id: number, date: string, time: string, customerEmail: string) {
        this.id = id;
        this.date = new Date(date);
        this.time = time;
        this.customerEmail = customerEmail;
    }
}

export default Order;