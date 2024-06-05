using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class Carro
    {
        public Carro()
        {
        }

        public int IdCarro { get; set; }
        public string? Matricula { get; set; }
        public int? Tara { get; set; }
        public int? Lotacao { get; set; }
        public int EstadoCarroIdEstadoCarro { get; set; }
        public int CategoriaCarroIdCategoriaCarro { get; set; }
        public int ModeloIdModelo { get; set; }

        public decimal? preco { get; set; }
        public string ImagemUrl { get; set; }  
    }
}
