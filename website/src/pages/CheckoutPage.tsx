import React, { useContext, useState } from 'react';
import { CartContext, CartItem } from '../contexts/CartContext';
import { calculateTotal } from '../utils/CartUtil';
import Image from '../components/Image';
import { Link } from 'react-router-dom';
import { AuthContext } from '../contexts/AuthContext';
import LoadingSpinner from '../components/Spinner';
import { createOrder } from '../services/OrderService';
import Orderline from '../models/Orderline';

const CheckoutPage: React.FC = () => {
    const { cart, setCart } = useContext(CartContext);
    const { customer } = useContext(AuthContext);
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [address, setAddress] = useState('');
    const [postalCode, setPostalCode] = useState('');
    const [city, setCity] = useState('');
    const [email, setEmail] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [cardNumber, setCardNumber] = useState('');
    const [cvc, setCvc] = useState('');
    const [expiryDate, setExpiryDate] = useState('');
    const [cardName, setCardName] = useState('');

    const [isSubmitting, setIsSubmitting] = useState(false);
    const [errors, setErrors] = useState<Record<string, string>>({});

    const validateInputs = () => {
        const errors: Record<string, string> = {};

        if (!firstName) {
            errors.firstName = 'Fornavn er påkrævet';
        }

        if (!lastName) {
            errors.lastName = 'Efternavn er påkrævet';
        }

        if (!address) {
            errors.address = 'Adresse er påkrævet';
        }

        if (!postalCode) {
            errors.postalCode = 'Postnummer er påkrævet';
        }

        if (!city) {
            errors.city = 'By er påkrævet';
        }

        if (!email || !/^\S+@\S+\.\S+$/.test(email)) {
            errors.email = 'Ugyldig email-adresse';
        }

        if (!phoneNumber || !/^\d{8}$/.test(phoneNumber)) {
            errors.phoneNumber = 'Ugyldigt telefonnummer';
        }

        if (!cardNumber || !/^\d{16}$/.test(cardNumber)) {
            errors.cardNumber = 'Ugyldigt kortnummer';
        }

        if (!cvc || !/^\d{3,4}$/.test(cvc)) {
            errors.cvc = 'Ugyldig CVC';
        }

        if (!expiryDate || !/^\d{2}\/\d{2}$/.test(expiryDate)) {
            errors.expiryDate = 'Ugyldig udløbsdato';
        }

        if (!cardName) {
            errors.cardName = 'Navn på kort er påkrævet';
        }

        setErrors(errors);

        return Object.keys(errors).length === 0;
    };

    if (!customer) return (
        <div className='container'>
            <p>Du skal være logget ind for at kunne bestille</p>
            <p>Kurven er gemt, så du kan fortsætte når du er logget ind</p>
            <Link to='/login' className='btn btn-primary mb-1'>Log ind</Link>
            <br />
            <Link to='/register' className='btn btn-primary'>Opret bruger</Link>
        </div>
    );

    const handleSubmit = async () => {
        if (!validateInputs()) {
            return;
        }

        setIsSubmitting(true);
        const orderlines: Orderline[] = cart.map((item: CartItem) => item.orderline);
        console.log(orderlines);
        const createdOrder = await createOrder(customer.id, orderlines)
        setIsSubmitting(false);

        if (!createdOrder) {
            alert('Der skete en fejl ved oprettelse af ordre');
            return;
        }

        alert('Din ordre er nu oprettet');
        window.location.href = '/';
        setCart([])

    };


    return (
        <div className='container'>
            <div className='row'>
                <div className='col-sm-12 col-md-6'>
                    <h2>Ordreoversigt</h2>
                    {cart.map((item: CartItem, index: number) => (
                        <div key={index}>
                            <Link to={`/product/${item.product.id}`} className='text-decoration-none text-dark'>
                                <div className='row m-2'>
                                    <div className='col-sm-12 col-md-6'>
                                        <Image image={item.product.image} imageTitle={item.product.name} className='img-fluid' />
                                    </div>
                                    <div className='col-sm-12 col-md-6'>
                                        <p>{item.product.name}</p>
                                        <p>{item.orderline.quantity} stk.</p>
                                        <p>{item.orderline.priceAtTimeOfOrder} kr.</p>
                                    </div>
                                </div>
                            </Link>
                            <hr />
                        </div>
                    ))}
                </div>
                <div className='col-sm-12 col-md-6'>
                    <h2>Leveringsoplysninger</h2>
                    <input type='text' placeholder='Fornavn' className='form-control mb-2' autoComplete='given-name' onChange={(e) => setFirstName(e.target.value)} />
                    {errors.firstName && <div className="text-danger mb-2">{errors.firstName}</div>}
                    <input type='text' placeholder='Efternavn' className='form-control mb-2' autoComplete="family-name" onChange={(e) => setLastName(e.target.value)} />
                    {errors.lastName && <div className="text-danger mb-2">{errors.lastName}</div>}
                    <input type='text' placeholder='Adresse' className='form-control mb-2' autoCapitalize='address' onChange={(e) => setAddress(e.target.value)} />
                    {errors.address && <div className="text-danger mb-2">{errors.address}</div>}
                    <input type='text' placeholder='Postnummer' className='form-control mb-2' autoComplete='postal-code' onChange={(e) => setPostalCode(e.target.value)} />
                    {errors.postalCode && <div className="text-danger mb-2">{errors.postalCode}</div>}
                    <input type='text' placeholder='By' className='form-control mb-2' autoComplete='address-level2' onChange={(e) => setCity(e.target.value)} />
                    {errors.city && <div className="text-danger mb-2">{errors.city}</div>}
                    <input type='text' placeholder='Email' className='form-control mb-2' autoComplete='email' onChange={(e) => setEmail(e.target.value)} />
                    {errors.email && <div className="text-danger mb-2">{errors.email}</div>}
                    <input type='text' placeholder='Telefonnummer' className='form-control mb-2' autoComplete='tel-national' onChange={(e) => setPhoneNumber(e.target.value)} />
                    {errors.phoneNumber && <div className="text-danger mb-2">{errors.phoneNumber}</div>}
                    <hr />
                    <h2>Betalingsoplysninger</h2>
                    <input type='text' placeholder='Kortnummer' className='form-control mb-2' autoComplete='cc-number' onChange={(e) => setCardNumber(e.target.value)} />
                    {errors.cardNumber && <div className="text-danger mb-2">{errors.cardNumber}</div>}
                    <input type='text' placeholder='CVC' className='form-control mb-2' autoComplete='cc-csc' onChange={(e) => setCvc(e.target.value)} />
                    {errors.cvc && <div className="text-danger mb-2">{errors.cvc}</div>}
                    <input type='text' placeholder='Udløbsdato' className='form-control mb-2' autoComplete='cc-exp' onChange={(e) => setExpiryDate(e.target.value)} />
                    {errors.expiryDate && <div className="text-danger mb-2">{errors.expiryDate}</div>}
                    <input type='text' placeholder='Navn på kort' className='form-control mb-2' autoComplete='cc-name' onChange={(e) => setCardName(e.target.value)} />
                    {errors.cardName && <div className="text-danger mb-2">{errors.cardName}</div>}
                    <hr />
                    <p>I alt {calculateTotal(cart)}</p>
                    <div className='row'>
                        {
                            isSubmitting ?
                                <>
                                    <button className='btn btn-primary mb-2' disabled>Bestil</button>
                                    <LoadingSpinner />
                                </>
                                :
                                <button className='btn btn-primary mb-2' onClick={handleSubmit}>Bestil</button>
                        }
                    </div>
                </div>
            </div>
        </div>
    );
};

export default CheckoutPage;