import { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../contexts/AuthContext";

type Props = {
    HideClass: string;
}
const LoginButtons = (props: Props) => {
    const { customer } = useContext(AuthContext);
    return (
        customer === null ? (
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
                    {customer.firstName}
                </button>
                <ul className="dropdown-menu text-center">
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
