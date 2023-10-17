import { useContext, useEffect } from "react";
import { AuthContext } from "../../contexts/AuthContext";

const LogoutPage = () => {
    const { setCustomer } = useContext(AuthContext);

    useEffect(() => {
        setCustomer(null);
        window.location.href = '/';
    }, [setCustomer]);

    return (
        <div>
            <h1>Logging out...</h1>
        </div>
    );
}

export default LogoutPage;