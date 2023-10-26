import React, { useState, ChangeEvent, useEffect } from 'react';
import './RegisterPage.css';
import { register } from "../../../services/AuthService";

class lableData {
    name: string;
    value: string;
    type: string;
    placeholder: string;
    constructor(name: string, value: string, type: string, placeholder: string) {
        this.name = name;
        this.value = value;
        this.type = type;
        this.placeholder = placeholder;
    }
}

const RegisterPage = () => {
    const [formdata1, setFormData1] = useState<lableData[]>([
        new lableData("FirstName", "", "text", "First Name"),
        new lableData("LastName", "", "text", "Last Name"),
        new lableData("Email", "", "email", "Email"),
        new lableData("PhoneNo", "", "text", "Phone Number"),
        new lableData("Password", "", "password", "Password"),
        new lableData("ConfirmPassword", "", "password", "ConfirmPassword"),
        new lableData("Street", "", "text", "Street"),
        new lableData("City", "", "text", "City"),
        new lableData("Zip", "", "text", "Zip"),
        new lableData("HouseNumber", "", "text", "HouseNumber"),
    ])
    const [formData, setFormData] = useState({ Error: '', });
    const [errorMessage, setErrorMessage] = useState<string>("");
    const [numberOfErrors, setNumberOfErrors] = useState<number>(0);

    const handleChange = (index: number) => (e: ChangeEvent<HTMLInputElement>) => {
        const { value } = e.target;
        // setFormData({ ...formData, [name]: value });

        setFormData1((prevFormData1: lableData[]) => {
            // Create a shallow copy of the previous state array
            const updatedFormData = [...prevFormData1];
            // Update the specific element at the given index
            updatedFormData[index] = { ...updatedFormData[index], value: value };
            // Return the updated array
            return updatedFormData;
        });
    };

    const handleConfirm = (e: React.FormEvent) => {
        e.preventDefault();
        let newErrorMessage = '';
        for (let i = 0; i < formdata1.length; i++) {
            const field = formdata1[i];
            const value = field.value;
            const placeholder = field.placeholder;

            // Additional validations
            switch (field.name) {
                case "FirstName":
                case "LastName":
                    if (value.length < 2 || value.length > 50) {
                        newErrorMessage += `${placeholder} must be between 2 and 50 characters.\n`;
                        setNumberOfErrors(numberOfErrors + 1);
                    }
                    break;
                case "Email":
                    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
                    if (!emailRegex.test(value)) {
                        newErrorMessage += `Invalid email format.\n`;
                        setNumberOfErrors(numberOfErrors + 1);
                    }
                    break;
                case "PhoneNo":
                    if (value.length < 6 || value.length > 20) {
                        newErrorMessage += `${placeholder} must be between 6 and 20 characters.\n`;
                        setNumberOfErrors(numberOfErrors + 1);
                    }
                    break;
                case "Password":
                    const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;
                    if (!passwordRegex.test(value)) {
                        newErrorMessage += `Password must contain at least one uppercase letter, one lowercase letter, and one number, and be at least 8 characters long.\n`;
                        setNumberOfErrors(numberOfErrors + 1);
                    }
                    break;
                case "ConfirmPassword":
                    if (value != formdata1[i - 1].value) {
                        newErrorMessage += `Passwords must match.\n`;
                        setNumberOfErrors(numberOfErrors + 1);
                    }
                    break;
                case "Street":
                    if (value.length < 2 || value.length > 100) {
                        newErrorMessage += `${placeholder} must be between 2 and 100 characters.\n`;
                        setNumberOfErrors(numberOfErrors + 1);
                    }
                    break;
                case "City":
                    if (value.length < 2 || value.length > 60) {
                        newErrorMessage += `${placeholder} must be between 2 and 60 characters.\n`;
                        setNumberOfErrors(numberOfErrors + 1);
                    }
                    break;
                case "Zip":
                    if (value.length < 1 || value.length > 10) {
                        newErrorMessage += `${placeholder} must be between 1 and 10 characters.\n`;
                        setNumberOfErrors(numberOfErrors + 1);
                    }
                    break;
                case "HouseNumber":
                    if (value.length < 1 || value.length > 4) {
                        newErrorMessage += `${placeholder} must be between 1 and 4 characters.\n`;
                        setNumberOfErrors(numberOfErrors + 1);
                    }
                    break;
                default:
                    break;
            }
        }
        if (numberOfErrors > 0) {
            setErrorMessage(newErrorMessage);
        }
        else {
            //Create new Customer/Address here.
        }
    };

    return (
        <div className="container text-center ">
            <div className='row'>

                <h1>RegisterPage</h1>
                <form className='col-12 px-5 ' onSubmit={handleConfirm}>
                    {
                        formdata1.map((data, index) => {
                            return (
                                <div key={index} className='form-group mx-auto'>
                                    <input
                                        type={data.type}
                                        name={data.name}
                                        value={data.value}
                                        onChange={handleChange(index)}
                                        placeholder={data.placeholder}
                                        required
                                    />
                                </div>
                            )
                        })
                    }
                    <div className="form-group text-center mx-auto">
                        {
                            errorMessage.split('\n').map((err, i) => <label key={i} className="text-danger d-block">{err}</label>)
                        }
                    </div>
                <input
                    className="btn btn-primary"
                    type='submit'
                />
                </form>
            </div>
        </div>
    );
};

export default RegisterPage;
