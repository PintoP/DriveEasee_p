import "./style.css";
import { BACKEND_URL } from "../../Config";
import axios from 'axios';
import React, { useState } from "react";

function cpostalhandler(cpostals) {
    if (!Array.isArray(cpostals)) {
        return cpostals;
    }
    return cpostals.map((cpostal, index) => (
        <div key={index}>{cpostal.inicio}</div>
    ));
}

export function Veiculos() {
    const [codigopostal, setcodigopostal] = useState("Nada a mostrar");

        axios.get(BACKEND_URL + "/Cpostal")
            .then(function (response) {
                setcodigopostal(cpostalhandler(response.data));
            })
            .catch(function (error) {
                console.log("Error: " + error);
            })
            .finally(function () {
                console.log("Finally.");
            });

    return (
        <div className="veiculos">
            <section className="vehicle-management">
                <h2>Veículos</h2>
                <div className="search-bar">
                    <input type="text" placeholder="Pesquisar por nome ou matrícula" />
                    <button type="submit"></button>
                </div>
                <div className="vehicle-list">
                    <div className="vehicle-item">
                        <div className="vehicle-details">
                            <div className="vehicle-name">{codigopostal}</div>
                            <p className="vehicle-status">status</p>
                            <p className="vehicle-price">preco</p>
                        </div>
                        <a href="descricao_carro.html" className="view-vehicle">Ver Veículo</a>
                    </div>
                </div>
                <div className="pagination">
                    <button className="pagination-button" disabled>Anterior</button>
                    <button className="pagination-button active">1</button>
                    <a href="veiculos2.html"><button className="pagination-button">2</button></a>
                    <a href="veiculos2.html"><button className="pagination-button">Próximo</button></a>
                </div>
            </section>
        </div>
    );
}
