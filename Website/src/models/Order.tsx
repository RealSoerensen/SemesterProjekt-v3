class Order {
    id: number;
    date: Date;
    time: string;
    customerId: number;


    constructor(id: number, date: string, time: string, customerId: number) {
        this.id = id;
        this.date = new Date(date);
        this.time = time;
        this.customerId = customerId;
    }
}

export default Order;