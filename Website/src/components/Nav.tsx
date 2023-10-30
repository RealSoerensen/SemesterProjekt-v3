import { useState } from 'react';
import { NavLink, Link } from 'react-router-dom'
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.js';
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


const Nav = () => {
    const [linkItem] = useState<NavbarLinks[]>([
        new NavbarLinks('Hjem', 'home'),
        new NavbarLinks('Om os', 'about'),
        new NavbarLinks('Kontakt os', 'contact')
    ]);
    const [expandNavBarMobile, setExpandNavBarMobile] = useState<boolean>(false);

    const ToggleNavBarMobile = () => {
        setExpandNavBarMobile(!expandNavBarMobile);
    }

    return (
        <nav className="navbar bg-white sticky-top navbar-expand-lg bg-body-tertiary">
            <div className='container'>
                <Link className="navbar-brand" to="/">Padel Shop</Link>
                <div className='d-flex align-items-center justify-content-center'>
                    <div className='mr-2'>
                        <Cart HideClass='d-block d-lg-none' />
                    </div>
                    <button className="navbar-toggler m-1" type="button" onClick={ToggleNavBarMobile}>
                        <span className="navbar-toggler-icon"></span>
                    </button>
                </div>


                <div className={expandNavBarMobile ? "navbar-collapse " : " collapse navbar-collapse"}>
                    <ul className="navbar-nav">
                        {
                            linkItem.map((item, index) => {
                                return (
                                    <li className="nav-item text-center" key={index}>
                                        <NavLink
                                            className={({ isActive, isPending }) =>
                                                isPending ? "" : isActive ? "nav-link active" : "nav-link"}
                                            to={`/${item.linkto.toLowerCase()}`}
                                        >
                                            {item.name}
                                        </NavLink>
                                    </li>
                                )
                            })
                        }
                        <li>
                            <LoginButtons HideClass='d-inline d-lg-none d-flex align-items-center justify-content-center' />
                        </li>
                    </ul>
                </div>
                <LoginButtons HideClass='d-inline d-none d-lg-block' />
                <Cart HideClass=' d-none d-lg-block' />
            </div>
        </nav>
    )



}

export default Nav