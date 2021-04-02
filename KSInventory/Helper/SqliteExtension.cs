using KSInventory.Database.Models;
using KSInventory.Interface;
using SQLite;
using Xamarin.Forms;

namespace KSInventory.Helper
{
    public static class SqliteExtension
    {
        public static SQLiteConnection GetConnection()
        {
            var connection = DependencyService.Get<ISQLite>().GetConnection();
            connection.CreateTable<ProductDetails>();
            connection.CreateTable<ProductSalesDetails>();
            connection.CreateTable<ProductStockDetails>();
            return connection;
        }
    }
}
