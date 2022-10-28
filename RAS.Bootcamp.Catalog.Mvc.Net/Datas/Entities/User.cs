using System;
using System.Collections.Generic;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Datas.Entities
{
    public partial class User
    {
        public User()
        {
            Keranjangs = new HashSet<Keranjang>();
            Pembelies = new HashSet<Pembely>();
            Penjuals = new HashSet<Penjual>();
            Transaksis = new HashSet<Transaksi>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Tipe { get; set; } = null!;

        public virtual ICollection<Keranjang> Keranjangs { get; set; }
        public virtual ICollection<Pembely> Pembelies { get; set; }
        public virtual ICollection<Penjual> Penjuals { get; set; }
        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
