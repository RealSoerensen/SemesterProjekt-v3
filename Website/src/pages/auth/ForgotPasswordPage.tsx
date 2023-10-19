import React from "react";

const ForgotPassword: React.FC = () => {
    return (
        <div>
            <h1>Glemt adgangskode</h1>
            <div>
                <label className='form-label'>Email:</label>
                <input
                    type="text"
                    className='form-control'
                    autoComplete="on"
                />
                <button type="button" className="btn btn-primary">Send nyt kodeord</button>
            </div>
        </div>
    );
};

export default ForgotPassword;