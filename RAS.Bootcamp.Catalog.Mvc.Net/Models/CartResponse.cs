namespace RAS.Bootcamp.Catalog.Mvc.Net.Models;
public class CartResponse {
    public int Id {get; set; }
    public int ProductId {get; set; }
    public string ProductName {get; set; }
    public string ImageUrl { get; set; }
    public decimal Harga { get; set; }
    public decimal SubTotall { 
        get {
            return Harga * Qty;
        }
    }
    public int Qty {get; set; }
}
