import React, { useState, ChangeEvent, FormEvent } from 'react';
import './RegisterPage.css';
import { checkEmailExists, register } from '../../../services/AuthService';
import Customer from "../../../models/Customer";
import Address from "../../../models/Address";
import { useNavigate } from 'react-router-dom';
import { UserAccount } from '../../../models/UserAccount';

type FormData = {
    name: string;
    value: string;
    type: string;
    placeholder: string;
};

const RegisterPage: React.FC = () => {
    const initialFormData: FormData[] = [
        { name: 'FirstName', value: '', type: 'text', placeholder: 'First Name' },
        { name: 'LastName', value: '', type: 'text', placeholder: 'Last Name' },
        { name: 'Email', value: '', type: 'email', placeholder: 'Email' },
        { name: 'PhoneNo', value: '', type: 'text', placeholder: 'Phone Number' },
        { name: 'Password', value: '', type: 'password', placeholder: 'Password' },
        { name: 'ConfirmPassword', value: '', type: 'password', placeholder: 'Confirm Password' },
        { name: 'Street', value: '', type: 'text', placeholder: 'Street' },
        { name: 'City', value: '', type: 'text', placeholder: 'City' },
        { name: 'Zip', value: '', type: 'text', placeholder: 'Zip' },
        { name: 'HouseNumber', value: '', type: 'text', placeholder: 'House Number' },
    ];

    const [formData, setFormData] = useState<FormData[]>(initialFormData);
    const [errorMessage, setErrorMessage] = useState<string>('');
    const navigate = useNavigate();

    const validateField = async (name: string, value: string, placeholder: string) => {
        let errorMessage = '';
        let errorCount = 0;

        switch (name) {
            case 'FirstName':
            case 'LastName':
                if (value.length < 2 || value.length > 50) {
                    errorMessage += `${placeholder} must be between 2 and 50 characters.\n`;
                    errorCount++;
                }
                break;
            case 'Email':
                const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
                if (!emailRegex.test(value)) {
                    errorMessage += 'Invalid email format.\n';
                    errorCount++;
                }
                try {
                    const emailExists = await checkEmailExists(value);
                    if (emailExists) {
                        errorMessage += 'Email already exists.\n';
                        errorCount++;
                    }
                } catch (error) {
                    console.error("Failed to check email:", error);
                    errorMessage += 'An error occurred while checking the email. Please try again.\n';
                    errorCount++;
                }
                break;
            case "PhoneNo":
                if (value.length < 6 || value.length > 20) {
                    errorMessage += `Phonenumber must be between 6 and 20 characters.\n`;
                    errorCount++;
                }
                break;
            case 'Password':
                const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;
                if (!passwordRegex.test(value)) {
                    errorMessage += 'Password must contain at least one uppercase letter, one lowercase letter, and one number, and be at least 8 characters long.\n';
                    errorCount++;
                }
                break;
            case "Street":
                if (value.length < 2 || value.length > 100) {
                    errorMessage += `Street must be between 2 and 100 characters.\n`;
                    errorCount++;
                }
                break;
            case "City":
                if (value.length < 2 || value.length > 60) {
                    errorMessage += `City must be between 2 and 60 characters.\n`;
                    errorCount++;
                }
                break;
            case "Zip":
                if (value.length < 1 || value.length > 10) {
                    errorMessage += `Zip must be between 1 and 10 characters.\n`;
                    errorCount++;
                }
                break;
            case 'HouseNumber':
                if (value.length < 1 || value.length > 4) {
                    errorMessage += `House Number must be between 1 and 4 characters\n`;
                    errorCount++;
                }
                break;
            default:
                break;
        }

        return { errorMessage, errorCount };
    };

    const registerCustomer = async (formData: FormData[]) => {
        const firstName = formData.find(f => f.name === 'FirstName')?.value;
        const lastName = formData.find(f => f.name === 'LastName')?.value;
        const email = formData.find(f => f.name === 'Email')?.value;
        const phoneNo = formData.find(f => f.name === 'PhoneNo')?.value;
        const password = formData.find(f => f.name === 'Password')?.value;

        const street = formData.find(f => f.name === 'Street')?.value;
        const city = formData.find(f => f.name === 'City')?.value;
        const zip = formData.find(f => f.name === 'Zip')?.value;
        const houseNumber = formData.find(f => f.name === 'HouseNumber')?.value;


        if (street && city && zip && houseNumber && firstName && lastName && email && phoneNo && password) {
            const newAddress: Address = {
                street: street,
                city: city,
                zip: zip,
                houseNumber: houseNumber,
                id: 0 // Placeholder, changed upon creation in database.
            };

            const newCustomer: Customer = {
                firstName: firstName,
                lastName: lastName,
                phoneNo: phoneNo,
                addressID: newAddress.id,
                id: 0  // Placeholder, changed upon creation in database.
            };

            const newUserAccount: UserAccount = {
                id: 0, // Placeholder, changed upon creation in database.
                email: email,
                password: password,
                customerId: newCustomer.id,
            };

            return await register(newCustomer, newUserAccount, newAddress);
        };
    };

    const handleChange = (index: number) => (e: ChangeEvent<HTMLInputElement>) => {
        const { value } = e.target;
        const updatedFormData = [...formData];
        updatedFormData[index].value = value;
        setFormData(updatedFormData);
    };

    const handleConfirm = async (event: FormEvent) => {
        event.preventDefault();
        let newErrorMessage = '';
        let errorsCount = 0;

        const validations = formData.map(async (field) => {
            const { name, value, placeholder } = field;
            const { errorMessage, errorCount } = await validateField(name, value, placeholder);
            newErrorMessage += errorMessage;
            errorsCount += errorCount;
        });

        await Promise.all(validations);

        setErrorMessage(newErrorMessage);

        if (errorsCount === 0) {
            const isCreated = await registerCustomer(formData);
            if (isCreated) {
                navigate('/');
            }
            else {
                setErrorMessage(newErrorMessage + "Unknown error occured while trying to make your account. Please try again.\n");
            }
        }
    };

    return (
        <div className="container text-center">
            <div className="row">
                <h1>RegisterPage</h1>
                <form className="col-12 px-5" onSubmit={handleConfirm}>
                    {formData.map((data, index) => (
                        <div key={index} className="form-group mx-auto">
                            <input
                                type={data.type}
                                name={data.name}
                                value={data.value}
                                onChange={handleChange(index)}
                                placeholder={data.placeholder}
                                required
                            />
                        </div>
                    ))}
                    <input className="btn btn-primary" type="submit" />
                    <div className="text-center mx-auto">
                        {
                            errorMessage.split('\n').map((err, i) => <label key={i} className="text-danger d-block">{err}</label>)
                        }
                    </div>
                </form>
            </div>
        </div>
    );
};

export default RegisterPage;