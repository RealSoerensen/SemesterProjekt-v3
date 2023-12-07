export class UserAccount {
    public id: number;
    public email: string;
    public password: string;
    public customerId: number;

    constructor(email: string, password: string, customerId: number, id: number) {
        this.email = email;
        this.password = password;
        this.customerId = customerId;
        this.id = id;
    }
}