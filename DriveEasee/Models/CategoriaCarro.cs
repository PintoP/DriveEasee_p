using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class CategoriaCarro
    {
        public CategoriaCarro()
        {
        }

        public int IdCategoriaCarro { get; set; }
        public string? NomeCategoria { get; set; }
        public int ModeloIdModelo { get; set; }

    }
}
