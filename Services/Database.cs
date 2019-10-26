using Android.Util;
using SQLite;
using System.IO;

namespace MyAsset.Services
{
    public partial class Database
    {
        readonly string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        readonly string fileName = Constants.DatabaseFileName;

        public bool Create()
        {
            try
            {
                using (var connection = new SQLiteConnection(Path.Combine(path, fileName)))
                {
                    connection.CreateTable<Model.Asset>();
                    connection.CreateTable<Model.AssetType>();

                    if (connection.Table<Model.AssetType>().Count() == 0)
                    {
                        var assetType = new Model.AssetType
                        {
                            Name = "Ingatlan"
                        };
                        connection.Insert(assetType);
                    }

                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}
