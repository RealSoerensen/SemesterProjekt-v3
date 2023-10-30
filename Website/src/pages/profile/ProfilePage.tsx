import { useContext, useState } from 'react'
import { Link } from 'react-router-dom';
import { AuthContext } from '../../contexts/AuthContext';
import Settings from './Settings';
import Orders from './Orders';
import Details from './Details';

const ProfilePage = () => {
    const { customer } = useContext(AuthContext);
    const [active, setActive] = useState<string>('Bestillinger');
    const [options] = useState<string[]>([
        "Bestillinger",
        "Oplysninger",
        "Indstillinger",
    ]);

    if (!customer) {
        return <div>
            Du er ikke logget ind
            <Link to="/login">Log ind</Link>
        </div>
    }

    const getActive = () => {
        if (active === 'Bestillinger') {
            return <Orders />
        } else if (active === 'Indstillinger') {
            return <Settings />
        } else if (active === 'Oplysninger') {
            return <Details />
        }
    }

    return (
        <div className="row flex-nowrap">
            <div className="col-auto col-xl-2 px-sm-2 bg-dark">
                <div className="d-flex flex-column align-items-center align-items-sm-start px-3 pt-2 text-white min-vh-100">
                    <span className="fs-5 d-none d-sm-inline mb-1">Hej {customer.firstName} {customer.lastName}</span>
                    <ul className="nav nav-pills flex-column mb-sm-auto align-items-center align-items-sm-start" id="menu">
                        {
                            options.map((option, index) => {
                                return (
                                    <li className="nav-item" key={index}>
                                        <button className={active === option ? "nav-link active" : "nav-link px-0"} onClick={() => setActive(option)} >
                                            {option}
                                        </button>
                                    </li>
                                )
                            })
                        }
                    </ul>
                </div>
            </div>
            <div className="col py-3">
                {getActive()}
            </div>
        </div>


    )
}

export default ProfilePage