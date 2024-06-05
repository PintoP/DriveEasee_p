import "./styles2.css";
import { BACKEND_URL } from "../../Config";
import axios from 'axios';
import React, { useState, useEffect } from "react";

function VeiculoItem({ carro, onClick }) {
    const [modelo, setModelo] = useState("Carregando...");
    const [estado, setEstado] = useState("Carregando...");

    useEffect(() => {
        axios.get(`${BACKEND_URL}/Modelo/${carro.modeloIdModelo}`)
            .then(response => {
                setModelo(response.data.nomeModelo);
            })
            .catch(error => {
                setModelo("Modelo Desconhecido");
            });

        axios.get(`${BACKEND_URL}/EstadoCarro/${carro.estadoCarroIdEstadoCarro}`)
            .then(response => {
                setEstado(response.data.nome);
            })
            .catch(error => {
                setEstado("Estado Desconhecido");
            });
    }, [carro.modeloIdModelo, carro.estadoCarroIdEstadoCarro]);

    return (
        <div className="car-item" onClick={() => onClick({ ...carro, modelo })}>
            <img src={carro.imagemUrl} alt={`Imagem de ${modelo}`} className="car-image" />
            <h3>{modelo}</h3>
            <p>€{carro.preco}</p>
            <button>Alugar</button>
        </div>
    );
}

export function Veiculos() {
    const [veiculos, setVeiculos] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedCar, setSelectedCar] = useState(null);
    const [dataInicio, setDataInicio] = useState("");
    const [dataFim, setDataFim] = useState("");
    const [caucao, setCaucao] = useState(0);
    const [precoFinal, setPrecoFinal] = useState(0);
    const [popupMessage, setPopupMessage] = useState("");
    const [aluguerData, setAluguerData] = useState(null);

    useEffect(() => {
        axios.get(`${BACKEND_URL}/Carro`)
            .then(response => {
                setVeiculos(response.data);
            })
            .catch(error => {
                console.log("Error fetching carros:", error);
            });
    }, []);

    const openModal = (carro) => {
        setSelectedCar(carro);
        setCaucao(carro.preco * 0.1);  // Calcula a caução como 10% do preço
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setIsModalOpen(false);
        setSelectedCar(null);
        setDataInicio("");
        setDataFim("");
        setCaucao(0);
        setPrecoFinal(0);
        setAluguerData(null);
    };

    const getNextAluguerId = async () => {
        try {
            const response = await axios.get(`${BACKEND_URL}/Aluguer`);
            const alugueres = response.data;
            const maxId = alugueres.reduce((max, aluguer) => (aluguer.idAluguer > max ? aluguer.idAluguer : max), 0);
            return maxId + 1;
        } catch (error) {
            console.error("Erro ao buscar o próximo idAluguer:", error);
            return 1; // Fallback para 1 em caso de erro
        }
    };

    const getCaucaoId = async (valorCaucao) => {
        try {
            const response = await axios.get(`${BACKEND_URL}/Caucao`);
            const caucoes = response.data;
            const existingCaucao = caucoes.find(caucao => caucao.valor === valorCaucao);

            if (existingCaucao) {
                return existingCaucao.idCaucao;
            } else {
                const maxId = caucoes.reduce((max, caucao) => (caucao.idCaucao > max ? caucao.idCaucao : max), 0);
                const newCaucao = {
                    idCaucao: maxId + 1,
                    valor: valorCaucao,
                    estado: "Não ativa"
                };
                const createResponse = await axios.post(`${BACKEND_URL}/Caucao`, newCaucao);
                return createResponse.data.idCaucao;
            }
        } catch (error) {
            console.error("Erro ao buscar ou criar caução:", error);
            throw error;
        }
    };

    const calcularPrecoFinal = (dataInicio, dataFim, precoDiario) => {
        const dataInicial = new Date(dataInicio);
        const dataFinal = new Date(dataFim);
        const diffTime = dataFinal.getTime() - dataInicial.getTime();
        const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
        return diffDays * precoDiario;
    };

    const handleDateChange = () => {
        if (dataInicio && dataFim) {
            const preco = calcularPrecoFinal(dataInicio, dataFim, selectedCar.preco);
            setPrecoFinal(preco);
        }
    };

    useEffect(() => {
        handleDateChange();
    }, [dataInicio, dataFim]);

    const confirmarAluguer = async () => {
        const idAluguer = await getNextAluguerId();

        if (!dataInicio || !dataFim || !precoFinal || !selectedCar) {
            setPopupMessage("Erro: Todos os campos são obrigatórios.");
            return;
        }

        try {
            const caucaoId = await getCaucaoId(caucao);

            const aluguerData = {
                idAluguer,
                dataInicio,
                dataFim,
                valor: precoFinal,
                clienteIdCliente: 1,
                carroIdCarro: selectedCar.idCarro,
                driveEaseIdDriveEase: 1,
                caucaoIdCaucao: caucaoId
            };

            setAluguerData(aluguerData);

            console.log("Dados do Aluguer:", aluguerData);  // Log para verificar os dados

            const response = await axios.post(`${BACKEND_URL}/Aluguer`, aluguerData);
            console.log("Aluguer confirmado:", response.data);
            setPopupMessage("Sucesso: Aluguer confirmado!");
            closeModal();
        } catch (error) {
            console.error("Erro ao confirmar aluguer:", error);
            setPopupMessage("Falha ao confirmar aluguer.");
        }
    };

    const closePopup = () => {
        setPopupMessage("");
        setAluguerData(null);
    };

    return (
        <div className="veiculos">
            <section className="vehicle-management">
                <h2>Veículos</h2>
                <div className="search-bar">
                    <input type="text" placeholder="Pesquisar por nome ou matrícula" />
                    <button type="submit"></button>
                </div>
                <main className="main-content">
                    <section className="car-listing">
                        <div className="vehicle-list">
                            {veiculos.map((carro, index) => (
                                <VeiculoItem
                                    key={index}
                                    carro={carro}
                                    onClick={openModal}
                                />
                            ))}
                        </div>
                    </section>
                </main>
                <div className="pagination">
                    <button className="pagination-button" disabled>Anterior</button>
                    <button className="pagination-button active">1</button>
                    <a href="veiculos2.html"><button className="pagination-button">2</button></a>
                    <a href="veiculos2.html"><button className="pagination-button">Próximo</button></a>
                </div>
                {isModalOpen && selectedCar && (
                    <div className="modal">
                        <div className="modal-content">
                            <span className="close" onClick={closeModal}>&times;</span>
                            <div>
                                <label>Modelo:</label>
                                <input type="text" value={selectedCar.modelo} readOnly />
                            </div>
                            <div>
                                <label>Preço:</label>
                                <input type="text" value={selectedCar.preco} readOnly />
                            </div>
                            <div>
                                <label>Caução (10% do preço):</label>
                                <input type="text" value={caucao} readOnly />
                            </div>
                            <div>
                                <label>Data de Início:</label>
                                <input
                                    type="date"
                                    value={dataInicio}
                                    onChange={(e) => setDataInicio(e.target.value)}
                                />
                            </div>
                            <div>
                                <label>Data Final:</label>
                                <input
                                    type="date"
                                    value={dataFim}
                                    onChange={(e) => setDataFim(e.target.value)}
                                />
                            </div>
                            <div>
                                <label>Preço Final:</label>
                                <input type="text" value={precoFinal} readOnly />
                            </div>
                            <button onClick={confirmarAluguer}>Confirmar Aluguer</button>
                        </div>
                    </div>
                )}
                {aluguerData && (
                    <div className="popup">
                        <div className="popup-content">
                            <span className="close" onClick={closePopup}>&times;</span>
                            <pre>{JSON.stringify(aluguerData, null, 2)}</pre>
                        </div>
                    </div>
                )}
            </section>
        </div>
    );
}

export default Veiculos;