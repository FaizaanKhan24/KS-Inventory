using System;
using System.IO;
using KSInventory.Droid.DependencyServices;
using KSInventory.Interface;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace KSInventory.Droid.DependencyServices
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string sqliteFileName = "KSInventory.db3";
            // Doucments Folder
            string documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsPath, sqliteFileName);

            // Create the connection
            var connection = new SQLiteConnection(path);

            // Return the database connection
            return connection;
        }
    }
}
