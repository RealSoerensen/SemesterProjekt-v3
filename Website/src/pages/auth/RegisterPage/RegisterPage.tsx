import React, { useState, ChangeEvent } from 'react';
import './RegisterPage.css';
import { register } from "../../../services/AuthService";

const RegisterPage = () => {
    const [formData, setFormData] = useState({
        FirstName: '',
        LastName: '',
        Email: '',
        PhoneNo: '',
        Password: '',
        ConfirmPassword: '',
        Street: '',
        City: '',
        Zip: '',
        HouseNumber: '',
        Button: '',
        Error: '',
    });

    const [errorMessage, setErrorMessage] = useState<string>("");

    const [numberOfErrors, setNumberOfErrors] = useState<number>(0);

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleConfirm = () => {
        setNumberOfErrors(0);
        if (formData.Email === '') {
            setErrorMessage(errorMessage + 'Email is required.\n');
            setNumberOfErrors(numberOfErrors + 1);
        }
    
        if (formData.FirstName === '') {
            setErrorMessage(errorMessage + 'First Name is required.\n');
            setNumberOfErrors(numberOfErrors + 1);
        }
    
        if (formData.LastName === '') {
            setErrorMessage(errorMessage + 'Last Name is required.\n');
            setNumberOfErrors(numberOfErrors + 1);
        }
        if(numberOfErrors === 0) {
            setErrorMessage('');
        }
        formData.Error = errorMessage;
    };
    

    return (
        <div>
            <h1>RegisterPage</h1>
            <form>
                <div className="form-group">
                    <input
                        type="text"
                        name="FirstName"
                        value={formData.FirstName}
                        onChange={handleChange}
                        placeholder="First Name"
                    />
                </div>
                <div className="form-group">
                    <input
                        type="text"
                        name="LastName"
                        value={formData.LastName}
                        onChange={handleChange}
                        placeholder="Last Name"
                    />
                </div>
                <div className="form-group">
                    <input
                        type="text"
                        name="Email"
                        value={formData.Email}
                        onChange={handleChange}
                        placeholder="Email"
                    />
                </div>
                <div className="form-group">
                    <input
                        type="text"
                        name="PhoneNo"
                        value={formData.PhoneNo}
                        onChange={handleChange}
                        placeholder="Phone Number"
                    />
                </div>
                <div className="form-group">
                    <input
                        type="password"
                        name="Password"
                        value={formData.Password}
                        onChange={handleChange}
                        placeholder="Password"
                    />
                </div>
                <div className="form-group">
                    <input
                        type="password"
                        name="ConfirmPassword"
                        value={formData.ConfirmPassword}
                        onChange={handleChange}
                        placeholder="Confirm Password"
                    />
                </div>
                <div className="form-group">
                    <input
                        type="text"
                        name="Street"
                        value={formData.Street}
                        onChange={handleChange}
                        placeholder="Street"
                    />
                </div>
                <div className="form-group">
                    <input
                        type="text"
                        name="City"
                        value={formData.City}
                        onChange={handleChange}
                        placeholder="City"
                    />
                </div>
                <div className="form-group">
                    <input
                        type="text"
                        name="Zip"
                        value={formData.Zip}
                        onChange={handleChange}
                        placeholder="Zip"
                    />
                </div>
                <div className="form-group">
                    <input
                        type="text"
                        name="HouseNumber"
                        value={formData.HouseNumber}
                        onChange={handleChange}
                        placeholder="House Number"
                    />
                </div>
                <button type="button" className="btn btn-primary" onClick={handleConfirm}>
                    Confirm
                </button>
                <div className="form-group">
                    <label>{formData.Error}</label>
                </div>
            </form>
        </div>
    );
};

export default RegisterPage;
