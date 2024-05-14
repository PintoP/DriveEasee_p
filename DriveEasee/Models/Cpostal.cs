using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class Cpostal
    {
        public Cpostal()
        {
        }

        public int IdCpostal { get; set; }
        public int? Inicio { get; set; }
        public int? Fim { get; set; }
        public string? Localizacao { get; set; }
    }
}
