import Status from "./OrderStatus";
class Order {
    id: number;
    date: Date;
    time: string;
    customerID: number;
    status: Status


    constructor(id: number, date: string, time: string, customerID: number, status: Status) {
        this.id = id;
        this.date = new Date(date);
        this.time = time;
        this.customerID = customerID;
        this.status = status;
    }
}

export default Order;