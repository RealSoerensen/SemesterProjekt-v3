import React from 'react'
import { AuthContext } from '../../contexts/AuthContext';

const ProfilePage = () => {
    const { customer } = React.useContext(AuthContext);

    if (!customer) {
        return <div>Not logged in</div>
    }

    return (
        <div>
            ProfilePage
            <div className="container">
                customer.id: {customer.getID()}
                <br />
                customer.firstName: {customer.getFirstName()}
                <br />
                customer.lastName: {customer.getLastName()}
                <br />
                customer.email: {customer.getEmail()}
            </div>
        </div>
    )
}

export default ProfilePage