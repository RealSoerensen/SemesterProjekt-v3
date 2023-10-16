import React, { useContext, useState } from "react";
import { AuthContext } from "../../contexts/AuthContext";
import { login } from "../../services/AuthService";
import { Link } from "react-router-dom";

interface LoginProps { }

const LoginPage: React.FC<LoginProps> = () => {
    const { setCustomer } = useContext(AuthContext);
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState("");
    const [success, setSuccess] = useState("");

    const handleLogin = async () => {
        if (email === '' || password === '') {
            setError('Username and password are required');
            return;
        }

        const customer = await login(email, password);
        console.log(customer);

        if (customer) {
            setSuccess('Logging in...');
            setError('');
            setTimeout(() => {
                setCustomer(customer);
                window.location.href = '/';
            }, 200);

        } else {
            setError('Invalid credentials');
        }
    };

    return (
        <form>
            <div className="pb-3">
                <label className='form-label'>Email:</label>
                <input
                    type="text"
                    className='form-control'
                    autoComplete="on"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <label className='form-label'>Password:</label>
                <input
                    type="password"
                    className='form-control'
                    autoComplete="on"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                {error && <p className='text-danger'>Error: {error}</p>}
                {success && <p className='text-success'>{success}</p>}
            </div>

            <button type="button" className="btn btn-primary" onClick={handleLogin}>Login</button>
            <br />
            <Link to="/forgot-password">Forgot password?</Link>
            <br />
            <Link to="/register">Don't have an account? Register here.</Link>
        </form>
    );
};

export default LoginPage;
