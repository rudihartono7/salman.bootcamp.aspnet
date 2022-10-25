using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.Catalog.Mvc.Net.Datas;
using RAS.Bootcamp.Catalog.Mvc.Net.Datas.Entities;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly EMarketDbContext _dbContext;

        public CheckoutController(EMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var userId = User.Claims.First(e => e.Type == ClaimTypes.NameIdentifier).Value;
            var id = int.Parse(userId);

            var listKeranjang = _dbContext.Keranjangs
                .Include(e => e.IdBarangNavigation)
                .ThenInclude(e => e.IdPenjualNavigation)
                .Where(e => e.IdUser == id)
                .ToList();

            return View(listKeranjang);
        }

        [HttpPost]
        public IActionResult Order()
        {
            var userId = User.Claims.First(e => e.Type == ClaimTypes.NameIdentifier).Value;
            var id = int.Parse(userId);

            var user = _dbContext.Users.Include(e => e.Pembelies).First(e => e.Id == id);
            var pembeli = user.Pembelies.First();

            var listKeranjang = _dbContext.Keranjangs.Where(e => e.IdUser == id).ToList();
            var sum = listKeranjang.Sum(e => e.Jumlah * e.HargaSatuan);

            // ke logic database

            var transaksi = new Transaksi();
            transaksi.IdUser = id;
            transaksi.TotalHarga = sum;
            transaksi.MetodePembayaran = "GHOIB";
            transaksi.StatusTransaksi = "WAITINGFORPAYMENT";
            transaksi.StatusBayar = "IGNORED";// gk dipakai
            transaksi.AlamatPengiriman = pembeli.Alamat;
            
            foreach (var item in listKeranjang)
            {
                var itemTransaksi = new ItemTransaksi();
                itemTransaksi.IdBarang = item.IdBarang;
                itemTransaksi.Jumlah = item.Jumlah;
                itemTransaksi.Harga = item.HargaSatuan;
                itemTransaksi.SubTotal = itemTransaksi.Jumlah * itemTransaksi.Harga;
                
                transaksi.ItemTransaksis.Add(itemTransaksi);
            }

            //ini untuk add transaski
            _dbContext.Transaksis.Add(transaksi);
            
            //ini untuk clear list keranjang
            _dbContext.Keranjangs.RemoveRange(listKeranjang);
            
            _dbContext.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
    }
}