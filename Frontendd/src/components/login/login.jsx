import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { BACKEND_URL } from '../../Config';
import './login.css';

function Login({ closeModal, onLoginSuccess }) {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post(`https://localhost:7072/api/Cliente/BearerToken`, { email, password });
            if (response.data.token) {
                localStorage.setItem('token', response.data.token);
                alert('Login successful');
                closeModal();
                window.location.reload();
            } else {
                alert('Login failed');
            }
        } catch (error) {
            alert('Login failed: ' + (error.response?.data || error.message));
        }
    };

    return (
        <div className="modal-overlay" id="loginModal">
            <div className="modal-content">
                <span className="close" onClick={closeModal}>&times;</span>
                <h2>Login/Registo</h2>
                <form onSubmit={handleLogin}>
                    <div className="form-group">
                        <label htmlFor="email">Email</label>
                        <input type="email" id="email" value={email} onChange={(e) => setEmail(e.target.value)} required />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Senha</label>
                        <input type="password" id="password" value={password} onChange={(e) => setPassword(e.target.value)} required />
                    </div>
                    <button type="submit" className="modal-button">Entrar</button>
                </form>
            </div>
        </div>
    );
}

export default Login;