import { useContext, useEffect } from 'react'
import { AuthContext } from '../../contexts/AuthContext';

const ProfilePage = () => {
    const { customer } = useContext(AuthContext);

    useEffect(() => {
        console.log(customer);
    }, [customer]);

    if (!customer) {
        return <div>Not logged in</div>
    }

    return (
        <div>
            <h1>ProfilePage</h1>
            <p>Customer: {customer.firstName} {customer.lastName}</p>
        </div>
    )
}

export default ProfilePage