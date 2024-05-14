using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class Devolucao
    {
        public int IdDevolucao { get; set; }
        public int TecnicoIdTecnico { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Hora { get; set; }
        public string? Tipo { get; set; }
        public decimal? ValorExtra { get; set; }
        public int AluguerIdAluguer { get; set; }

    }
}
