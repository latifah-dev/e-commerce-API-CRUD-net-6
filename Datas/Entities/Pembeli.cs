using System;
using System.Collections.Generic;

namespace PALUGADA.API.Datas.Entities
{
    public partial class Pembeli
    {
        public Pembeli()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdPembeli { get; set; }
        public string? NamaPembeli { get; set; }
        public string? AlamatPembeli { get; set; }
        public string? NotelpPembeli { get; set; }
        public string? NegaraPembeli { get; set; }
        public int? IdUser { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
