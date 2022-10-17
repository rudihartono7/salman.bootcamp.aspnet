using System;
using System.Collections.Generic;

namespace RAS.Bootcamp.Api.Net.Datas.Entities
{
    public partial class Barang
    {
        public int Id { get; set; }
        public string Kode { get; set; } = null!;
        public string Nama { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Harga { get; set; }
        public int Stok { get; set; }
        public int IdPenjual { get; set; }

        public virtual Penjual IdPenjualNavigation { get; set; } = null!;
    }
}
