import { useContext, useEffect } from "react";
import { AuthContext } from "../../contexts/AuthContext";

const LogoutPage = () => {
    const { setUser } = useContext(AuthContext);

    useEffect(() => {
        setUser(null);
        window.location.href = '/';
    }, [setUser]);

    return (
        <div>
            <h1>Logger ud...</h1>
        </div>
    );
}

export default LogoutPage;