namespace RAS.Bootcamp.Api.Net.Datas;

public class RequestBarang
{
    public string Kode { get; set; } = null!;
    public string Nama { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Harga { get; set; }
    public int Stok { get; set; }
    public int IdPenjual { get; set; }
}