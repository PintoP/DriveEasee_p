using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
        }

        public int IdModelo { get; set; }
        public string? NomeModelo { get; set; }
        public int MarcaIdMarca { get; set; }

    }
}
