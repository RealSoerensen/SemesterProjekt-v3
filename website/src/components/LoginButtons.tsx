import { useContext, useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../contexts/AuthContext";
import { getCustomerById } from "../services/CustomerService";
import Customer from "../models/Customer";

type Props = {
    HideClass: string;
}

const LoginButtons = (props: Props) => {
    const { user } = useContext(AuthContext);
    const [customer, setCustomer] = useState<Customer>();

    useEffect(() => {
        const fetchCustomer = async () => {
            if (!user) return;
            const data = await getCustomerById(user.customerID);
            if (data !== null) {
                setCustomer(data);
            }
        }
        fetchCustomer();
    }, [user]);

    return (
        user === null ? (
            <div className={`text-center ${props.HideClass}`}>
                <Link to="/login">
                    <button className="btn btn-primary m-1" type="button">
                        Login
                    </button>
                </Link>

                <Link to="/register">
                    <button className="btn btn-primary m-1" type="button">
                        Register
                    </button>
                </Link>
            </div>
        ) : (
            <div className={`dropdown m-1 ${props.HideClass} `}>
                <button className="btn btn-primary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="true">
                    {customer?.firstName}
                </button>
                <ul className="dropdown-menu">
                    <Link to="/profile" className="text-decoration-none text-dark">
                        <li className='dropdown-item'>Konto</li>
                    </Link>
                    <Link to="/logout" className="text-decoration-none text-dark">
                        <li className='dropdown-item'>Log ud</li>
                    </Link>
                </ul>
            </div>
        )
    )
}

export default LoginButtons
