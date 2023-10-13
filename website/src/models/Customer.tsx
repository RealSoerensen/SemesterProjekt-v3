class Customer {
    private id: number;
    private firstName: string;
    private lastName: string;
    private email: string;
    private password: string;
    private addressID: number;
    private phone: string;

    constructor(id: number, firstName: string, lastName: string, email: string, password: string, addressID: number, phone: string) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
        this.addressID = addressID;
        this.phone = phone;
    }

    public getID(): number {
        return this.id;
    }

    public getFirstName(): string {
        return this.firstName;
    }

    public getLastName(): string {
        return this.lastName;
    }

    public getEmail(): string {
        return this.email;
    }

    public getPassword(): string {
        return this.password;
    }

    public getAddressID(): number {
        return this.addressID;
    }

    public getPhone(): string {
        return this.phone;
    }

    public setID(id: number): void {
        this.id = id;
    }

    public setFirstName(firstName: string): void {
        this.firstName = firstName;
    }

    public setLastName(lastName: string): void {
        this.lastName = lastName;
    }

    public setEmail(email: string): void {
        this.email = email;
    }

    public setPassword(password: string): void {
        this.password = password;
    }

    public setAddressID(addressID: number): void {
        this.addressID = addressID;
    }

    public setPhone(phone: string): void {
        this.phone = phone;
    }
}

export default Customer;
