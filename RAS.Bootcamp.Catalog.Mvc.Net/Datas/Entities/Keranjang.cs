using System;
using System.Collections.Generic;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Datas.Entities
{
    public partial class Keranjang
    {
        public int Id { get; set; }
        public int IdBarang { get; set; }
        public decimal HargaSatuan { get; set; }
        public int IdUser { get; set; }
        public int Jumlah { get; set; }

        public virtual Barang IdBarangNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
