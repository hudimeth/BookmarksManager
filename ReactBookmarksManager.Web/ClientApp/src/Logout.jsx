import React, { useEffect } from 'react';
import axios from 'axios';
import { useAuth } from './AuthContextComponent';
import { useNavigate } from 'react-router-dom';

const Logout = () => {
    const { setUser } = useAuth();
    const navigate = useNavigate();

    useEffect(() => {
        const doLogout = async () => {
            await axios.post('/api/account/logout');//gotta do the backend
            setUser(null);
            navigate('/');
        }
        doLogout();
    }, [])

    return (<></>)
}
export default Logout;