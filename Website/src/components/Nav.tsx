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
                <div className='d-block d-lg-none d-xl-none'>
                    <Cart HideClass=''/>
                    <button className="navbar-toggler d-inline m-1" type="button" onClick={ToggleNavBarMobile}>
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
                    </ul>
                    <LoginButtons HideClass='d-lg-none' />
                </div>
                <Cart HideClass='d-none d-lg-block'/>
                <LoginButtons HideClass='d-none d-lg-block' />

            </div>
        </nav>
    )



}

export default Nav