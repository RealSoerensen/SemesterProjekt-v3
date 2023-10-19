import { useState } from 'react';
import { NavLink, Link } from 'react-router-dom'
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.js';
import Cart from './Cart';
import LoginButtons from './LoginButtons';

const Nav = () => {
    const [linkItem] = useState<string[]>([
        'Hjem',
        'Om os',
        'Kontakt os'
    ]);
    const [expandNavBarMobile, setExpandNavBarMobile] = useState<boolean>(false);

    const ToggleNavBarMobile = () => {
        setExpandNavBarMobile(!expandNavBarMobile);
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
                                        >
                                            {link}
                                        </NavLink>
                                    </li>
                                )
                            })
                        }
                    </ul>
                </div>
                <Cart />
                <LoginButtons />
            </div>
        </nav>
    )



}

export default Nav