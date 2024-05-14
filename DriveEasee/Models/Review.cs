using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class Review
    {
        public int IdReview { get; set; }
        public string? Observacoes { get; set; }
        public int AluguerIdAluguer { get; set; }

    }
}
