import { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../contexts/AuthContext";

const LoginButtons = () => {
    const { customer } = useContext(AuthContext);
    return (
        customer === null ? (
            <div>
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
            <div className="dropdown m-1">
                <button className="btn btn-primary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    {customer.firstName}
                </button>
                <ul className="dropdown-menu">
                    <Link to="/profile">
                        <li className='dropdown-item'>Konto</li>
                    </Link>
                    <Link to="/logout">
                        <li className='dropdown-item'>Log ud</li>
                    </Link>
                </ul>
            </div>
        )
    )
}

export default LoginButtons
