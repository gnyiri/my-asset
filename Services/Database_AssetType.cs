using Android.Util;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System;

namespace MyAsset.Services
{
    public partial class Database
    {
        public Model.AssetType AssetTypeById(int ID)
        {
            try
            {
                return Instance.Connection.Get<Model.AssetType>(ID);
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
    }
}