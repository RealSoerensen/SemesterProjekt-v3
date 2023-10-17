class Customer {
    public firstName: string;
    public lastName: string;
    public email: string;
    public password: string;
    public addressID: number;
    public phoneNo: string;
    public registerDate: Date;

    constructor(firstName: string, lastName: string, email: string, password: string, addressID: number, phoneNo: string, registerDate: Date) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
        this.addressID = addressID;
        this.phoneNo = phoneNo;
        this.registerDate = registerDate;
    }
}

export default Customer;
