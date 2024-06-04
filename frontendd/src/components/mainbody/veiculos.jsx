import "./style.css";
import { BACKEND_URL } from "../../Config"
import axios from 'axios';

export function Veiculos() {

    axios.get(BACKEND_URL + "/Cpostal")
        .then(function (response) {
            console.log("Response: " + response);
     })
        .catch(function (error) {
            console.log("Error: " + error);
     })
     .finally(function(){
         console.log("Finaly.");
     })

    return (
        <div className="veiculos">

            <section class="vehicle-management">
                <h2>Veículos</h2>
                <div class="search-bar">
                    <input type="text" placeholder="Pesquisar por nome ou matrícula"/>
                        <button type="submit"></button>
                </div>
                <div class="vehicle-list">
                    <div class="vehicle-item">

                        <div class="vehicle-details">
                            <p class="vehicle-name">Nome</p>
                            <p class="vehicle-status">status</p>
                            <p class="vehicle-price">preco</p>
                        </div>
                        <a href="descricao_carro.html" class="view-vehicle">Ver Veículo</a>
                    </div>
                </div>
                <div class="pagination">
                    <button class="pagination-button" disabled>Anterior</button>
                    <button class="pagination-button active">1</button>
                    <a href="veiculos2.html"><button class="pagination-button">2</button></a>
                    <a href="veiculos2.html"><button class="pagination-button">Próximo</button></a>
                </div>
            </section>

        </div>
    );

}