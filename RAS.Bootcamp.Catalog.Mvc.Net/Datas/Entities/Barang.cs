using System;
using System.Collections.Generic;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Datas.Entities
{
    public partial class Barang
    {
        public Barang()
        {
            ItemTransaksis = new HashSet<ItemTransaksi>();
            Keranjangs = new HashSet<Keranjang>();
        }

        public int Id { get; set; }
        public string Kode { get; set; } = null!;
        public string Nama { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Harga { get; set; }
        public int Stok { get; set; }
        public int IdPenjual { get; set; }
        public string Filename { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual Penjual IdPenjualNavigation { get; set; } = null!;
        public virtual ICollection<ItemTransaksi> ItemTransaksis { get; set; }
        public virtual ICollection<Keranjang> Keranjangs { get; set; }
    }
}
