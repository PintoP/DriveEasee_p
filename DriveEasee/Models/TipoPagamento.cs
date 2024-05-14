using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class TipoPagamento
    {
        public TipoPagamento()
        {
        }

        public int IdTipoPagamento { get; set; }
        public string? NomeTipo { get; set; }
    }
}
