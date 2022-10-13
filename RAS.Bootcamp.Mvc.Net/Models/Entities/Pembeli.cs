using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAS.Bootcamp.Mvc.Net.Models.Entities;

public class Pembeli {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }
    [ForeignKey("User")]
    public int IdUser { get; set; }
    public string Alamat { get; set; }
    [StringLength(15)]
    public string NoHp { get; set; }
    
    public virtual User User { get; set;}
}