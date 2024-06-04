import "./style.css"; // Imports the style.css file

export function Topbar() {
    return (
        <div class="left-menu">  {/* Class for styling */}
            <li><a href="inicial.html"><i class="fas fa-home"></i> In�cio</a></li>
            <li><a href="veiculos.html" class="active">  {/* Active class for styling */}<i class="fas fa-car"></i> Ve�culos</a></li>
            <li><a href="parceiros.html"><i class="fas fa-handshake"></i> Parceiros</a></li>
            <li><a href="assistencia.html"><i class="fas fa-life-ring"></i> Assist�ncia</a></li>
            <li><a href="gfeedbacks.html"><i class="fas fa-comments"></i> Feedbacks</a></li>
        </div>
    );
}
