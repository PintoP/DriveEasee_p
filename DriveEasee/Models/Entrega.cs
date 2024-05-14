using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class Entrega
    {
        public int IdEntrega { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Hora { get; set; }
        public int TecnicoIdTecnico { get; set; }
        public int AluguerIdAluguer { get; set; }

    }
}
