namespace RAS.Bootcamp.Catalog.Mvc.Net.Datas.Entities
{
    public partial class User
    {
        public User()
        {
            Pembelies = new HashSet<Pembely>();
            Penjuals = new HashSet<Penjual>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Tipe { get; set; } = null!;

        public virtual ICollection<Pembely> Pembelies { get; set; }
        public virtual ICollection<Penjual> Penjuals { get; set; }
    }
}
