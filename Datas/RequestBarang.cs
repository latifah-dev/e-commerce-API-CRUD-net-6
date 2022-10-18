using System;
using System.Collections.Generic;

namespace PALUGADA.API.Datas.Entities
{
    public class RequestBarang
    {

        public string? KodeBarang { get; set; }
        public string? NamaBarang { get; set; }
        public string? JenisBarang { get; set; }
        public int? HargaBarang { get; set; }
        public int? StokBarang { get; set; }
        public string? DeskripsiBarang { get; set; }
        public uint? GambarBarang { get; set; }
        public int? IdPenjual { get; set; }
    }
}
