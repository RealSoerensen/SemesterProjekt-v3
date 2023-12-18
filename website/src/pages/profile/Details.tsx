import { useCallback, useContext, useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../../contexts/AuthContext";
import Address from "../../models/Address";
import { getAddressById, updateAddress } from "../../services/AddressService";
import { getCustomerById, updateCustomer } from "../../services/CustomerService";
import Customer from "../../models/Customer";
import { update } from "../../services/UserAccountService";

const Details = () => {
    const { user, setUser } = useContext(AuthContext);
    const [address, setAddress] = useState<Address>();
    const [firstName, setFirstName] = useState<string>('');
    const [lastName, setLastName] = useState<string>('');
    const [email, setEmail] = useState<string>('');
    const [phoneNo, setPhoneNo] = useState<string>('');
    const [street, setStreet] = useState<string>('');
    const [houseNumber, setHouseNumber] = useState<string>('');
    const [zip, setZip] = useState<string>('');
    const [city, setCity] = useState<string>('');
    const [customer, setCustomer] = useState<Customer>();

    const fetchUser = useCallback(async () => {
        if (!user) return;
        const data = await getCustomerById(user.customerID);
        if (data !== null) {
            setCustomer(data);
        }
    }, [user]);

    useEffect(() => {
        fetchUser();
    }, [fetchUser]);

    useEffect(() => {
        if (customer !== undefined) {
            setFirstName(customer.firstName);
            setLastName(customer.lastName);
            setEmail(user?.email || '');
            setPhoneNo(customer.phoneNo);
            getAddressById(customer.addressID).then((data: Address | null) => {
                if (data !== null) {
                    setAddress(data);
                    setStreet(data.street);
                    setHouseNumber(data.houseNumber);
                    setZip(data.zip);
                    setCity(data.city);
                }
            });
        }
    }, [customer, user]);

    if (!customer) {
        return <div>
            Du er ikke logget ind
            <Link to="/login">Log ind</Link>
        </div>
    }

    function handleCustomerSave() {
        if (!customer) return;
        const newCustomer = {
            ...customer,
            firstName: firstName,
            lastName: lastName,
            phoneNo: phoneNo,
        }

        updateCustomer(newCustomer).then((data: boolean) => {
            if (data) {
                alert('Oplysninger gemt');
            } else {
                alert('Noget gik galt');
            }
        });

        setCustomer(newCustomer);
    }

    function handleUserAccountSave() {
        if (!user) return;
        const newUser = {
            ...user,
            email: email,
        }

        update(user).then((data: boolean) => {
            if (data) {
                alert('Oplysninger gemt');
                setUser(newUser);
            } else {
                alert('Noget gik galt');
            }
        });

    }


    function handleAddressSave() {
        if (!address) return alert('Noget gik galt');
        const newAddress = {
            ...address,
            street: street,
            houseNumber: houseNumber,
            zip: zip,
            city: city,
        }

        updateAddress(newAddress).then((data: boolean) => {
            if (data) {
                alert('Oplysninger gemt');
            } else {
                alert('Noget gik galt');
            }
        });
    }

    return (
        <div>
            <div className="row">
                <div className="col">
                    <h4>Konto oplysninger</h4>
                    <div className="input-group mb-3">
                        <span className="input-group-text" id="inputGroup-sizing-default">Email</span>
                        <input type="text" className="form-control" defaultValue={email} onChange={(e) => setEmail(e.target.value)} />
                    </div>
                    <button type="button" className="btn btn-primary" onClick={handleUserAccountSave}>Gem</button>
                    <h4> Personlige Oplysninger</h4>
                    <div className="input-group mb-3">
                        <span className="input-group-text">For- og efternavn</span>
                        <input type="text" aria-label="First name" className="form-control" defaultValue={firstName} onChange={(e) => setFirstName(e.target.value)} />
                        <input type="text" aria-label="Last name" className="form-control" defaultValue={lastName} onChange={(e) => setLastName(e.target.value)} />
                    </div>
                    <div className="input-group mb-3">
                        <span className="input-group-text" id="inputGroup-sizing-default">Telefon nummer</span>
                        <input type="text" defaultValue={phoneNo} className="form-control" onChange={(e) => setPhoneNo(e.target.value)} />
                    </div>
                    <button type="button" className="btn btn-primary" onClick={handleCustomerSave}>Gem</button>
                </div>
                <div className="col">
                    <h4>Address</h4>
                    <div className="input-group mb-3">
                        <span className="input-group-text">Vejnavn</span>
                        <input type="text" aria-label="First name" className="form-control" defaultValue={street} onChange={(e) => setStreet(e.target.value)} />
                    </div>
                    <div className="input-group mb-3">
                        <span className="input-group-text">Husnummer</span>
                        <input type="text" aria-label="Last name" className="form-control" defaultValue={houseNumber} onChange={(e) => setHouseNumber(e.target.value)} />
                    </div>
                    <div className="input-group mb-3">
                        <span className="input-group-text">Postnummer</span>
                        <input type="text" aria-label="Last name" className="form-control" defaultValue={zip} onChange={(e) => setZip(e.target.value)} />
                    </div>
                    <div className="input-group mb-3">
                        <span className="input-group-text">By</span>
                        <input type="text" aria-label="Last name" className="form-control" defaultValue={city} onChange={(e) => setCity(e.target.value)} />
                    </div>
                    <button type="button" className="btn btn-primary" onClick={handleAddressSave}>Gem</button>
                </div>
            </div>
        </div>

    )
}

export default Details