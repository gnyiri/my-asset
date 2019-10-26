using Android.Util;
using SQLite;
using System.Collections.Generic;
using System.IO;

namespace MyAsset.Services
{
    public partial class Database
    {
        public bool InsertAsset(Model.Asset asset)
        {
            try
            {
                using (var connection = new SQLiteConnection(Path.Combine(path, fileName)))
                {
                    connection.Insert(asset);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Model.Asset> GetAssets()
        {
            try
            {
                using (var connection = new SQLiteConnection(Path.Combine(path, fileName)))
                {
                    return connection.Table<Model.Asset>().ToList();
                }

            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool Update(Model.Asset asset)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(path, fileName)))
                {
                    connection.Query<Model.Asset>("UPDATE Asset set Name=?", asset.Name);
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