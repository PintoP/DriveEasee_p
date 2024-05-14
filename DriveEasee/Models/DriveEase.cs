using System;
using System.Collections.Generic;

namespace DriveEasee.Models
{
    public partial class DriveEases
    {
        public DriveEases()
        {
        }

        public int IdDriveEase { get; set; }
        public string? Nome { get; set; }
        public string? Morada { get; set; }
        public int? Ntelemovel { get; set; }
        public string? Email { get; set; }
        public int CpostalIdCpostal { get; set; }

    }
}
