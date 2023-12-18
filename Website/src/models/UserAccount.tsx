export class UserAccount {
    public email: string;
    public password: string;
    public customerID: number;

    constructor(email: string, password: string, customerID: number) {
        this.email = email;
        this.password = password;
        this.customerID = customerID;
    }
}