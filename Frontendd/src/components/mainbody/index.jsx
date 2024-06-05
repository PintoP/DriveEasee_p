import "./style.css";
import { BACKEND_URL } from "../../Config";
import axios from 'axios';
import React, { useState } from "react";


export function Main() {

return (
<main>
    <section class="hero">
        <div class="hero-text">
            <h1 class="company-name">DriveEase</h1>
            <h2>O Melhor Aluguer de Carros em Todo o Mundo</h2>
            <p>Os membros recebem descontos exclusivos de até 15%! Registe-se/Faça login <a id="heroLoginLink">aqui</a></p>
            <button id="saibaMaisBtn">Saiba Mais</button>
        </div>
        <div class="search-form">
            <form id="searchForm">
                <div class="form-group">
                    <label for="pais">País</label>
                    <select id="pais" required>
                        <option value="">Selecione o País</option>
                        <option value="portugal">Portugal</option>
                        <option value="espanha">Espanha</option>
                        <option value="franca">França</option>
                       
                    </select>
                </div>
                <div class="form-group">
                    <label for="cidade">Cidade</label>
                    <select id="cidade" required>
                        <option value="">Selecione a Cidade</option>
                      
                    </select>
                </div>
                <div class="form-group">
                    <label for="data-inicio">Data de Início</label>
                    <input type="date" id="data-inicio" required/>
                </div>
                <div class="form-group">
                    <label for="data-fim">Data de Fim</label>
                    <input type="date" id="data-fim" required/>
                </div>
                <button type="submit" id="searchButton">Pesquisar</button>
            </form>
        </div>
    </section>

 
    <section class="feedbacks">
        <h2>O que nossos clientes dizem</h2>
        <div class="feedback">
            <p>"Serviço excelente e carros em ótimas condições!"</p>
            <p>- João Silva</p>
        </div>
        <div class="feedback">
            <p>"Muito fácil de reservar e atendimento ótimo!"</p>
            <p>- Maria Fernandes</p>
        </div>
        <div class="feedback">
            <p>"Os melhores preços e grande variedade de veículos."</p>
            <p>- Carlos Souza</p>
        </div>
        <div class="feedback">
            <p>"Excelente experiência do início ao fim."</p>
            <p>- Ana Pereira</p>
        </div>
        <div class="feedback">
            <p>"Experiência incrível! Recomendo."</p>
            <p>- Tiago Saramago</p>
        </div>
    </section>

  
    <section class="overlay-section"></section>
    </main>
    )
}