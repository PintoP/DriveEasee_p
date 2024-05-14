using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class Aluguer
    {
        public Aluguer()
        {
        }

        public int IdAluguer { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public decimal? Valor { get; set; }
        public int ClienteIdCliente { get; set; }
        public int CarroIdCarro { get; set; }
        public int DriveEaseIdDriveEase { get; set; }
        public int CaucaoIdCaucao { get; set; }
    }
}
