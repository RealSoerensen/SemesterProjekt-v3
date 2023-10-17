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
            <div className="dropdown ">
                <button className="btn btn-primary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    {customer.firstName}
                </button>
                <ul className="dropdown-menu">
                    <Link to="/profile">
                        <li className='dropdown-item'>Profile</li>
                    </Link>
                    <Link to="/settings">
                        <li className='dropdown-item'>Settings</li>
                    </Link>
                    <Link to="/logout">
                        <li className='dropdown-item'>Logout</li>
                    </Link>
                </ul>
            </div>
        )
    )
}

export default LoginButtons