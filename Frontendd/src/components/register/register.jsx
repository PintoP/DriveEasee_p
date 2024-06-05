import React, { useState } from 'react';
import axios from 'axios';
import { BACKEND_URL } from '../../Config';
import './register.css';

const Register = ({ closeModal, onRegisterSuccess }) => {
    const [nome, setNome] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [morada, setMorada] = useState('');
    const [ntelemovel, setNtelemovel] = useState('');
    const [cpostalIdCpostal, setCpostalIdCpostal] = useState('');

    const handleRegister = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post(`https://localhost:7072/api/Cliente/`, {
                nome,
                email,
                password,
                morada,
                ntelemovel,
                cpostalIdCpostal,
            });
            if (response.status === 201) {
                alert('Register successful');
                closeModal();
                onRegisterSuccess();
            } else {
                alert('Register failed: ' + response.data);
            }
        } catch (error) {
            const errorMessage = error.response?.data?.message || error.message || 'Unknown error occurred';
            alert('Register failed: ' + errorMessage);
        }
    };

    return (
        <div className="modal-overlay">
            <div className="modal-content">
                <span className="close" onClick={closeModal}>&times;</span>
                <h2>Registo</h2>
                <form onSubmit={handleRegister}>
                    <div className="form-group">
                        <label htmlFor="nome">Nome</label>
                        <input
                            type="text"
                            id="nome"
                            name="nome"
                            value={nome}
                            onChange={(e) => setNome(e.target.value)}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="email">Email</label>
                        <input
                            type="email"
                            id="email"
                            name="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Senha</label>
                        <input
                            type="password"
                            id="password"
                            name="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="morada">Morada</label>
                        <input
                            type="text"
                            id="morada"
                            name="morada"
                            value={morada}
                            onChange={(e) => setMorada(e.target.value)}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="ntelemovel">Nº Telemóvel</label>
                        <input
                            type="text"
                            id="ntelemovel"
                            name="ntelemovel"
                            value={ntelemovel}
                            onChange={(e) => setNtelemovel(e.target.value)}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="cpostalIdCpostal">Código Postal</label>
                        <input
                            type="text"
                            id="cpostalIdCpostal"
                            name="cpostalIdCpostal"
                            value={cpostalIdCpostal}
                            onChange={(e) => setCpostalIdCpostal(e.target.value)}
                            required
                        />
                    </div>
                    <button type="submit" className="modal-button">Registrar</button>
                </form>
            </div>
        </div>
    );
}

export default Register;
