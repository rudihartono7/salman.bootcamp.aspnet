namespace RAS.Bootcamp.Catalog.Mvc.Net.Datas.Entities
{
    public partial class Penjual
    {
        public Penjual()
        {
            Barangs = new HashSet<Barang>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public string NamaToko { get; set; } = null!;
        public string Alamat { get; set; } = null!;

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Barang> Barangs { get; set; }
    }
}
