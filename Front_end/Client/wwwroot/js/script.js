var loginModal = document.getElementById("loginModal");

// Obter o botão que abre o modal de login/registo
var btnLogin = document.getElementById("loginBtn");
var heroLoginLink = document.getElementById("heroLoginLink");

// Obter o elemento <span> que fecha o modal de login/registo
var closeLoginModal = document.getElementById("closeLoginModal");

// Quando o usuário clicar no botão, abre o modal de login/registo
btnLogin.onclick = function () {
    showModal(loginModal);
}
heroLoginLink.onclick = function () {
    showModal(loginModal);
}

// Quando o usuário clicar no <span> (x), fecha o modal de login/registo
closeLoginModal.onclick = function () {
    hideModal(loginModal);
}

// Quando o usuário clicar em qualquer lugar fora do modal de login/registo, fecha o modal
window.onclick = function (event) {
    if (event.target == loginModal) {
        hideModal(loginModal);
    }
}