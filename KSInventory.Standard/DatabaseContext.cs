using System.IO;
using KSInventory.Database.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace KSInventory.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<ColorDetails> ColorDetails { get; set; }

        public DatabaseContext()
        {
            //Database.EnsureDeleted();
            Database.OpenConnection();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = string.Empty;

            if (Device.RuntimePlatform == Device.Android)
                dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ProductDB.db");
            else if (Device.RuntimePlatform == Device.iOS)
                dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "..", "Library", "ProductDB.db");

            optionsBuilder.UseSqlite(string.Format("Filename={0}", dbPath));
        }
    }
}