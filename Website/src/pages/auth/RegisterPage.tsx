import React, { useState, ChangeEvent } from 'react';
import './RegisterPage.css';
import { register } from "../../services/AuthService";

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
    });

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleConfirm = () => {
        let errorMessages = '';
        let numberOfErrors = 0;
    
        // if (formData.Email === '') {
        //     errorMessages += 'Email is required.\n';
        //     numberOfErrors += 1;
        // }
    
        // if (formData.FirstName === '') {
        //     errorMessages += 'First Name is required.\n';
        //     numberOfErrors += 1;
        // }
    
        // if (formData.LastName === '') {
        //     errorMessages += 'Last Name is required.\n';
        //     numberOfErrors += 1;
        // }
    };
    

    return (
        <div>
            <h1>RegisterPage</h1>
            <form>
                <div className="form-group">
                    <label>First Name</label>
                    <input
                        type="text"
                        name="FirstName"
                        value={formData.FirstName}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Last Name</label>
                    <input
                        type="text"
                        name="LastName"
                        value={formData.LastName}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Email</label>
                    <input
                        type="text"
                        name="Email"
                        value={formData.Email}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Phone Number</label>
                    <input
                        type="text"
                        name="PhoneNo"
                        value={formData.PhoneNo}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Password</label>
                    <input
                        type="password"
                        name="Password"
                        value={formData.Password}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Confirm Password</label>
                    <input
                        type="password"
                        name="ConfirmPassword"
                        value={formData.ConfirmPassword}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Street</label>
                    <input
                        type="text"
                        name="Street"
                        value={formData.Street}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>City</label>
                    <input
                        type="text"
                        name="City"
                        value={formData.City}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>ZIP</label>
                    <input
                        type="text"
                        name="Zip"
                        value={formData.Zip}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>House Number</label>
                    <input
                        type="text"
                        name="HouseNumber"
                        value={formData.HouseNumber}
                        onChange={handleChange}
                    />
                </div>
                <button type="button" className="btn btn-primary" onClick={handleConfirm}>
                    Confirm
                </button>
                <div className="form-group">
                    <label>Error</label>
                </div>
            </form>
        </div>
    );
};

export default RegisterPage;
