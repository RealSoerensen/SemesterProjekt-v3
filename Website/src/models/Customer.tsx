class Customer {
    public id: number;
    public firstName: string;
    public lastName: string;
    public addressID: number;
    public phoneNo: string;

    constructor(firstName: string, lastName: string, addressID: number, phoneNo: string, id: number) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.addressID = addressID;
        this.phoneNo = phoneNo;
        this.id = id;
    }
}

export default Customer;
