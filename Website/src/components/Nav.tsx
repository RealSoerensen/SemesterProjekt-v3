import { useContext } from 'react'
import { useState } from 'react';
import { AuthContext } from '../contexts/AuthContext';
import { NavLink, Link } from 'react-router-dom'
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.js';
<<<<<<< Updated upstream
=======
import Cart from './Cart';
import LoginButtons from './LoginButtons';


class NavbarLinks {
    name: string;
    linkto: string;
    constructor(name: string, linkto: string) {
        this.name = name;
        this.linkto = linkto;
    }
}

>>>>>>> Stashed changes

const Nav = () => {
    const [linkItem] = useState<string[]>([
        'Home',
        'About',
        'Contact'
    ]);
    const { customer } = useContext(AuthContext);

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
            </div>
        )
    }

    return (
        <nav className="navbar bg-white sticky-top navbar-expand-lg bg-body-tertiary">
            <div className='container'>
                <Link className="navbar-brand" to="/">Padel Shop</Link>
<<<<<<< Updated upstream
                <button className="navbar-toggler" type="button" onClick={ToggleNavBarMobile}>
                    <span className="navbar-toggler-icon"></span>
                </button>
=======
                <div className='d-block d-lg-none d-xl-none'>
                    <Cart HideClass='' />
                    <button className="navbar-toggler d-inline m-1" type="button" onClick={ToggleNavBarMobile}>
                        <span className="navbar-toggler-icon"></span>
                    </button>
                </div>
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
                {
                    handleUserContext()
                }
=======
                <Cart HideClass='d-none d-lg-block' />
                <LoginButtons HideClass='d-none d-lg-block' />

>>>>>>> Stashed changes
            </div>
        </nav>
    )



}

export default Nav