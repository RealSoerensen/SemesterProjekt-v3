import React, { useState, ChangeEvent, useEffect } from 'react';
import './RegisterPage.css';
import { register } from "../../../services/AuthService";
class lableData {
    name: string;
    value: string;
    type: string;
    placeholder: string;
    constructor(name:string, value: string, type:string, placeholder: string ) {
        this.name = name;
        this.value = value;
        this.type = type;
        this.placeholder = placeholder;
    }
}

const RegisterPage = () => {
    const [formdata1, setFormData1] = useState<lableData[]>([
        new lableData("FirstName","", "text", "First Name"),
        new lableData("LastName","", "text", "Last Name"),
        new lableData("Email","", "email", "Email"),
        new lableData("PhoneNo","", "text", "Phone Number"),
        new lableData("Password","", "password", "Password"),
        new lableData("ConfirmPassword","", "password","ConfirmPassword" ),
        new lableData("Street","", "text", "Street"),
        new lableData("City","", "text", "City"),
        new lableData("Zip","", "text", "Zip"),
        new lableData("HouseNumber","", "text", "HouseNumber"),
    ]) 
    const [formData, setFormData] = useState({Error: '',});
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

    const handleConfirm = () => {
        let newErrorMessage = '';
        for(let i =0; i<formdata1.length; i++){
            if(formdata1[i].value ==="" ){
                newErrorMessage += `${formdata1[i].placeholder} is required, `
            } 
            
        }
        setErrorMessage(newErrorMessage);
    };
    return (
        <div className="container text-center ">
            <div className='row'>

            <h1>RegisterPage</h1>
            <form className='col-12 px-5 'onSubmit={handleConfirm}>
                {
                    formdata1.map((data, index) => {
                        return(
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
                <input
                className="btn btn-primary"
                 type='submit'
                />
                <div className="form-group">
                    <label>{formData.Error}</label>
                </div>
            </form>
            </div>
        </div>
    );
};

export default RegisterPage;