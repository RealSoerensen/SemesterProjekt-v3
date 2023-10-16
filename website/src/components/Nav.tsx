import React from 'react'
import { useState } from 'react';
import { NavLink, Link } from 'react-router-dom'
import 'bootstrap/dist/css/bootstrap.css';
import './Nav.css'
type Props = {}

const Nav = (props: Props) => {
    const [linkItem, setlinkItem] = useState<string[]>([
        'Home',
        'About',
        'Contact'
    ]);
    const [buttonText, setButtonText] = useState<string[]>([
        'Sign up',
        'Sign in'
    ]);
    const [expandNavBarMobile, setExpandNavBarMobile] = useState<boolean>(false);
    const ToggleNavBarMobile = () => {
        setExpandNavBarMobile(!expandNavBarMobile);
    }

    return (
        <nav className="navbar sticky-top navbar-expand-lg bg-body-tertiary">
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
                    <div className='text-center'>
                        {
                            buttonText.map((button, index) => {
                                return (
                                    <div className="d-inline m-1 d-lg-none .d-xl-block" key={index}>
                                        <button className={button === 'Sign up' ? "btn btn-outline-success m-1" : "btn btn-outline-primary m-1"}
                                            type="submit">{button}</button>
                                    </div>
                                )
                            })
                        }
                    </div>
                </div>
                {
                    buttonText.map((button, index) => {
                        return (
                            <div className="d-none d-lg-block d-xl-block" key={index}>
                                <button className={button === 'Sign up' ? "btn btn-outline-success m-1" : "btn btn-outline-primary m-1"}
                                    type="submit">{button}</button>
                            </div>
                        )
                    })
                }
            </div>
        </nav>
    )
}

export default Nav