using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class Pagamento
    {
        public Pagamento()
        {
        }

        public int IdPagamento { get; set; }
        public int AluguerIdAluguer { get; set; }
        public double Valor { get; set; }
        public string? Metodo { get; set; }
        public DateTime? Data { get; set; }
        public int TipoPagamentoIdTipoPagamento { get; set; }

    }
}
