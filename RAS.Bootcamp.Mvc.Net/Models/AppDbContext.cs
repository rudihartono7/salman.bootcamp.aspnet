using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.Mvc.Net.Models.Entities;

namespace RAS.Bootcamp.Mvc.Net.Models;

public class AppDbContext: DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Penjual> Penjuals { get; set; }
    public DbSet<Barang> Barangs { get; set; }
    public DbSet<Pembeli> Pembelies { get; set; }
}
