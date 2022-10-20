public class BarangRequest {
    public string Kode {get;set;}
    public string Nama {get;set;}
    public decimal Harga {get;set;}
    public string Description {get;set;}
    public IFormFile? FileImage { get; set; }
}
