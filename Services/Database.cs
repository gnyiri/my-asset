using Android.Util;
using SQLite;
using System;
using System.IO;

namespace MyAsset.Services
{
    public partial class Database
    {
        private static Database INSTANCE = null;
        private static readonly object padlock = new object();

        private const int LAST_DATABASE_VERSION = 1;
        private readonly SQLiteConnection connection;
        private static readonly string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        Database()
        {
            try
            {
                connection = new SQLiteConnection(Path.Combine(path, Constants.DatabaseFileName));

                connection.CreateTable<Model.Asset>();
                connection.CreateTable<Model.AssetType>();

                if (connection.Table<Model.AssetType>().Count() == 0)
                {
                    var assetType = new Model.AssetType
                    {
                        Name = "Ingatlan"
                    };

                    connection.Insert(assetType);

                    assetType.Name = "Autó";

                    connection.Insert(assetType);
                }

                if (connection.Table<Model.Asset>().Count() == 0)
                {
                    var asset = new Model.Asset
                    {
                        Name = "Ház",
                        EstimatedValue = 15000000,
                        AssetTypeId = 1,
                        AssetStatusId = 1
                    };

                    connection.Insert(asset);

                    asset.Name = "Autó";
                    asset.EstimatedValue = 1000000;
                    asset.AssetTypeId = 2;
                }

                UpgradeDatabaseIfNecessary();
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
            }
        }

        public SQLiteConnection Connection 
        {
            get { return connection; }
        }

        public static Database Instance
        {
            get
            {
                lock (padlock)
                {
                    if (INSTANCE == null)
                    {
                        INSTANCE = new Database();
                    }

                    return INSTANCE;
                }
            }
        }   
        private void SetDatabaseToVersion(int version)
        {
            connection.Execute("PRAGMA user_version = " + version);
        }
        private int GetDatabaseVersion()
        {
            return connection.Execute("PRAGMA user_version");
        }
        private void UpgradeDatabaseIfNecessary()
        {
            int currentDbVersion = GetDatabaseVersion();

            if (currentDbVersion < LAST_DATABASE_VERSION)
            {
                int startUpgradingFrom = currentDbVersion + 1;

                switch (startUpgradingFrom)
                {
                    case 1: //starting version
                    case 2:
                        UpgradeFrom1To2();
                        goto case 3;
                    case 3:
                        UpgradeFrom2To3();
                        goto case 4;
                    case 4: //ecc.. ecc..
                        break;
                    default:
                        throw new Exception("something went really wrong");
                }

                SetDatabaseToVersion(LAST_DATABASE_VERSION);
            }
        }

        private static void UpgradeFrom1To2() { }
        private static void UpgradeFrom2To3() { }
    }
}
