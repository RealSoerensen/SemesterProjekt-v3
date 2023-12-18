import { useContext, useEffect, useState } from 'react'
import { Link } from 'react-router-dom';
import { AuthContext } from '../../contexts/AuthContext';
import Settings from './Settings';
import Orders from './Orders';
import Details from './Details';
import { getCustomerById } from '../../services/CustomerService';
import Customer from '../../models/Customer';

const ProfilePage = () => {
    const { user } = useContext(AuthContext);
    const [customer, setCustomer] = useState<Customer>();
    const [active, setActive] = useState<string>('Bestillinger');
    const options = {
        'Bestillinger': <Orders />,
        'Indstillinger': <Settings />,
        'Oplysninger': <Details />
    };

    useEffect(() => {
        const fetchCustomer = async () => {
            if (!user) return;
            const data = await getCustomerById(user.customerID);
            if (data !== null) {
                setCustomer(data);
            }
        }
        fetchCustomer();
    }, [user]);

    if (!customer) {
        return <div>
            Du er ikke logget ind
            <Link to="/login">Log ind</Link>
        </div>
    }

    return (
        <div className="row flex-nowrap">
            <div className="col-auto col-xl-2 px-sm-2 bg-dark">
                <div className="d-flex flex-column align-items-center align-items-sm-start px-3 pt-2 text-white min-vh-100">
                    <span className="fs-5 d-none d-sm-inline mb-1">Hej {customer.firstName} {customer.lastName}</span>
                    <ul className="nav nav-pills flex-column mb-sm-auto align-items-center align-items-sm-start" id="menu">
                        {
                            Object.keys(options).map((option) => (
                                <li key={option} className="nav-item">
                                    <button className={`nav-link ${active === option ? 'active' : 'px-0'}`} onClick={() => setActive(option)}>{option}</button>
                                </li>
                            ))
                        }
                    </ul>
                </div>
            </div>
            <div className="col py-3">
                {options[active as keyof typeof options]}
            </div>
        </div>
    )
}

export default ProfilePage