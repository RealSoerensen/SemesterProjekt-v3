import React, { useContext, useState } from "react";
import { AuthContext } from "../../contexts/AuthContext";
import { login } from "../../services/AuthService";
import { Link } from "react-router-dom";

const LoginPage: React.FC = () => {
    const { setUser } = useContext(AuthContext);
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState("");
    const [success, setSuccess] = useState("");

    const handleLogin = async () => {
        if (email === '' || password === '') {
            setError('Username and password are required');
            return;
        }

        const user = await login(email, password);

        if (user) {
            setSuccess('Logging in...');
            setError('');
            setTimeout(() => {
                setUser(user);
                window.location.href = '/';
            }, 200);

        } else {
            setError('Invalid credentials');
        }
    };

    return (
        <form className="position-absolute top-50 start-50 translate-middle">
            <label className='form-label'>Email:</label>
            <input
                type="text"
                className='form-control mb-1'
                autoComplete="on"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
            />
            <label className='form-label'>Adgangskode:</label>
            <input
                type="password"
                className='form-control mb-1'
                autoComplete="on"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            {error && <p className='text-danger'>Fejl: {error}</p>}
            {success && <p className='text-success'>{success}</p>}
            <button type="button" className="btn btn-primary mt-2" onClick={handleLogin}>Login</button>

            <div className="mt-1">
                <Link to="/forgot-password">Glemt adgangskode?</Link>
                <br />
                <Link to="/register">Har du ikke en konto? Register dig her.</Link>
            </div>
        </form>
    );
};

export default LoginPage;
