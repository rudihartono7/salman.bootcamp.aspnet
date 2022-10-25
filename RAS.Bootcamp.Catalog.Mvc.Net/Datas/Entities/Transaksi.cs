using System;
using System.Collections.Generic;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Datas.Entities
{
    public partial class Transaksi
    {
        public Transaksi()
        {
            ItemTransaksis = new HashSet<ItemTransaksi>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        /// <summary>
        /// Ini adalah total dari jumlah kali harga satuan
        /// </summary>
        public decimal TotalHarga { get; set; }
        public string MetodePembayaran { get; set; } = null!;
        /// <summary>
        /// WAITINGFORPAYMENT/PAYED/ONPROCESS/DELIVER/COMPLETED
        /// </summary>
        public string StatusTransaksi { get; set; } = null!;
        /// <summary>
        /// WAITINGFORPAYMENT/PAYED
        /// </summary>
        public string StatusBayar { get; set; } = null!;
        public string AlamatPengiriman { get; set; } = null!;

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<ItemTransaksi> ItemTransaksis { get; set; }
    }
}
