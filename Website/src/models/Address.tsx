class Address {
    public addressID: number;
    public street: string;
    public city: string;
    public zip: string;
    public houseNumber: string;

    constructor(addressID: number, street: string, city: string, zip: string, houseNumber: string) {
        this.addressID = addressID;
        this.street = street;
        this.city = city;
        this.zip = zip;
        this.houseNumber = houseNumber;
    }
}

export default Address;