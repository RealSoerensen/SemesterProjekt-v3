import { useState } from 'react';
import { Link } from 'react-router-dom'
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.js';
import Cart from './Cart';
import LoginButtons from './LoginButtons';

const Nav = () => {
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
                        <li>
                            <Link to="category" className='text-decoration-none text-dark d-flex justify-content-center  mx-3 my-2'>Kategorier</Link>
                        </li>
                        <li>
                            <Link to="About" className='text-decoration-none text-dark d-flex justify-content-center mx-auto my-2'>Om os</Link>
                        </li>
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