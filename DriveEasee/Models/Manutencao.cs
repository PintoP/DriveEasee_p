using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class Manutencao
    {
        public int IdManutencao { get; set; }
        public string? Proposito { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Hora { get; set; }
        public decimal? Custo { get; set; }
        public int CarroIdCarro { get; set; }

    }
}
