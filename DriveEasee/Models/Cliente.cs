using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
        }

        public int IdCliente { get; set; }
        public int CpostalIdCpostal { get; set; }
        public string? Nome { get; set; }
        public string? Morada { get; set; }
        public int? Ntelemovel { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
