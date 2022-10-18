using System;
using System.Collections.Generic;

namespace PALUGADA.API.Datas.Entities
{
    public partial class Penjual
    {
        public Penjual()
        {
            Barangs = new HashSet<Barang>();
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdPenjual { get; set; }
        public string? KodeToko { get; set; }
        public string? NamaToko { get; set; }
        public string? AlamatToko { get; set; }
        public int? IdUser { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<Barang> Barangs { get; set; }
        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
