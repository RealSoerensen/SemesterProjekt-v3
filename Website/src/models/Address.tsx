class Address {
    public id: number;
    public street: string;
    public city: string;
    public zip: string;
    public houseNumber: string;

    constructor(street: string, city: string, zip: string, houseNumber: string, addressID: number = 0) {
        this.id = addressID;
        this.street = street;
        this.city = city;
        this.zip = zip;
        this.houseNumber = houseNumber;
    }
}

export default Address;