import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import './topbar.css';

const Topbar = ({ onLoginClick, onRegisterClick, isLoggedIn, handleLogout }) => {
    return (
        <nav>
            <ul>
                <div className="left-menu">
                    <li><Link to="/"><i className="fas fa-home"></i> Início</Link></li>
                    <li><Link to="/veiculos"><i className="fas fa-car"></i> Veículos</Link></li>
                    <li><Link to="/parceiros"><i className="fas fa-handshake"></i> Parceiros</Link></li>
                    <li><Link to="/assistencia"><i className="fas fa-life-ring"></i> Assistência</Link></li>
                    <li><Link to="/gfeedbacks"><i className="fas fa-comments"></i> Feedbacks</Link></li>
                </div>
                <div className="right-menu">
                    {isLoggedIn ? (
                        <li className="account">
                            <a href="#" onClick={handleLogout}>
                                <i className="fas fa-user"></i>
                            </a>
                        </li>
                    ) : (
                        <>
                            <li className="account">
                                <a href="#" onClick={onLoginClick}>
                                    <i className="fas fa-user"></i> Login
                                </a>
                            </li>
                            <li className="account">
                                <a href="#" onClick={onRegisterClick}>
                                    <i className="fas fa-user-plus"></i> Registrar
                                </a>
                            </li>
                        </>
                    )}
                </div>
            </ul>
        </nav>
    );
}

export default Topbar;



