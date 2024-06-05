
import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { Footer } from "./components/footer/index";
import { Main } from "./components/mainbody/index";
import { Veiculos } from "./components/mainbody/Veiculos"
import  Topbar  from "./components/topbar/index";
import Login from './components/login/login'; // Importar o componente Login
import '../src/components/topbar/topbar.css';


function App() {
    const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    useEffect(() => {
        const token = localStorage.getItem('token');
        if (token) {
            setIsLoggedIn(true);
        }
    }, []);

    const openLoginModal = () => {
        setIsLoginModalOpen(true);
    };

    const closeLoginModal = () => {
        setIsLoginModalOpen(false);
    };

    const handleLoginSuccess = () => {
        setIsLoggedIn(true);
        setIsLoginModalOpen(false);
    };

    const handleLogout = () => {
        localStorage.removeItem('token');
        setIsLoggedIn(false);
    };


    return (
        <Router>
            <Topbar onLoginClick={openLoginModal} isLoggedIn={isLoggedIn} handleLogout={handleLogout} />
            <Routes>
                <Route path="/" element={<Main />} />
                <Route path="/veiculos" element={<Veiculos />} />

            </Routes>
            <Footer />
            {isLoginModalOpen && <Login closeModal={closeLoginModal} onLoginSuccess={handleLoginSuccess} />}
        </Router>
    );
}

export default App;
