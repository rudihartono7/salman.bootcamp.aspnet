using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAS.Bootcamp.Mvc.Net.Models.Entities;

public class Transaksi {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }
    [ForeignKey("User")]
    public int IdUser {get; set; }
    public decimal TotalHarga { get; set; }
    public string MetodePembayaran { get; set; }
    public string StatusTransaksi { get; set; }
    public string StatusBayar { get; set; }
    public string AlamatPengiriman {get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<ItemTransaksi> ItemTransaksi {get; set; }
}
