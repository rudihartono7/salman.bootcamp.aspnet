using System;
using System.Collections.Generic;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Datas.Entities
{
    public partial class ItemTransaksi
    {
        public int Id { get; set; }
        public int IdBarang { get; set; }
        public decimal Harga { get; set; }
        public int Jumlah { get; set; }
        public decimal SubTotal { get; set; }
        public int IdTransaksi { get; set; }

        public virtual Barang IdBarangNavigation { get; set; } = null!;
        public virtual Transaksi IdTransaksiNavigation { get; set; } = null!;
    }
}
