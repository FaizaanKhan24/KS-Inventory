using SQLite;

namespace KSInventory.Interface
{
    public interface ISQLite
    {
        /// <summary>
        /// Get SQLite connection.
        /// </summary>
        /// <returns> SQLiteConnection </returns>
        SQLiteConnection GetConnection();
    }
}
