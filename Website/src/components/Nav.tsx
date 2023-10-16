import { useContext } from 'react'
import { useState } from 'react';
import { AuthContext } from '../contexts/AuthContext';
import { NavLink, Link } from 'react-router-dom'
import 'bootstrap/dist/css/bootstrap.css';

const Nav = () => {
    const [linkItem] = useState<string[]>([
        'Home',
        'About',
        'Contact'
    ]);
    const { customer, setCustomer } = useContext(AuthContext);

    const [expandNavBarMobile, setExpandNavBarMobile] = useState<boolean>(false);
    const ToggleNavBarMobile = () => {
        setExpandNavBarMobile(!expandNavBarMobile);
    }

    function handleUserContext() {
        if (!customer) {
            return (
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
            )
        }

        return (
            <div>
                <Link to="/profile">
                    <button className="btn btn-primary m-1" type="button">
                        Profile
                    </button>
                </Link>

                <button className="btn btn-primary m-1" type="button" onClick={() => setCustomer(null)}>
                    Logout
                </button>
            </div>
        )

    }

    return (
        <nav className="navbar bg-white sticky-top navbar-expand-lg bg-body-tertiary">
            <div className='container'>
                <Link className="navbar-brand" to="/">Padel Shop</Link>
                <button className="navbar-toggler" type="button" onClick={ToggleNavBarMobile}>
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className={expandNavBarMobile ? "navbar-collapse " : " collapse navbar-collapse"}>
                    <ul className="navbar-nav">
                        {
                            linkItem.map((link, index) => {
                                return (
                                    <li className="nav-item text-center" key={index}>
                                        <NavLink
                                            className={({ isActive, isPending }) =>
                                                isPending ? "" : isActive ? "nav-link active" : "nav-link"}
                                            to={`/${link.toLowerCase() === 'home' ? '' : link.toLowerCase()}`}
                                        >{link}</NavLink>
                                    </li>
                                )
                            })
                        }
                    </ul>
                </div>
                {
                    handleUserContext()
                }
            </div>
        </nav>
    )



}

export default Nav