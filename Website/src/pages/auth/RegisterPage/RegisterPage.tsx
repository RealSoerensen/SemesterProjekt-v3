import React, { useState, ChangeEvent } from 'react';
import './RegisterPage.css';
import { register } from '../../../services/AuthService';

// Define a type for form fields
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
    const [numberOfErrors, setNumberOfErrors] = useState<number>(0);

    const handleChange = (index: number) => (e: ChangeEvent<HTMLInputElement>) => {
        const { value } = e.target;
        const updatedFormData = [...formData];
        updatedFormData[index].value = value;
        setFormData(updatedFormData);
    };

    const handleConfirm = () => {
        let newErrorMessage = '';
        let errorsCount = 0;

        formData.forEach((field) => {
            const { name, value, placeholder } = field;

            if (value === '') {
                newErrorMessage += `${placeholder} is required, `;
                errorsCount++;
                return;
            }

            switch (name) {
                case 'FirstName':
                case 'LastName':
                    if (value.length < 2 || value.length > 50) {
                        newErrorMessage += `${placeholder} must be between 2 and 50 characters, `;
                        errorsCount++;
                    }
                    break;
                case 'Email':
                    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
                    if (!emailRegex.test(value)) {
                        newErrorMessage += 'Invalid email format, ';
                        errorsCount++;
                    }
                    break;
                case 'Password':
                    const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;
                    if (!passwordRegex.test(value)) {
                        newErrorMessage += 'Password must contain at least one uppercase letter, one lowercase letter, and one number, and be at least 8 characters long, ';
                        errorsCount++;
                    }
                    break;
                case 'Street':
                case 'City':
                case 'Zip':
                case 'HouseNumber':
                    if (value.length < 1 || value.length > 4) {
                        newErrorMessage += `${placeholder} must be between 1 and 4 characters, `;
                        errorsCount++;
                    }
                    break;
                default:
                    break;
            }
        });

        setNumberOfErrors(errorsCount);
        setErrorMessage(newErrorMessage);
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
                    <div className="form-group">
                        <label>{errorMessage}</label>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default RegisterPage;
