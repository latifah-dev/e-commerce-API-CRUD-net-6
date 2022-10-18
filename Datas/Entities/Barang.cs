using System;
using System.Collections.Generic;

namespace PALUGADA.API.Datas.Entities
{
    public partial class Barang
    {
        public Barang()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdBarang { get; set; }
        public string? KodeBarang { get; set; }
        public string? NamaBarang { get; set; }
        public string? JenisBarang { get; set; }
        public int? HargaBarang { get; set; }
        public int? StokBarang { get; set; }
        public string? DeskripsiBarang { get; set; }
        public uint? GambarBarang { get; set; }
        public int? IdPenjual { get; set; }

        public virtual Penjual? IdPenjualNavigation { get; set; }
        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
