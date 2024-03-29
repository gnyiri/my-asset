﻿using Android.Util;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System;

namespace MyAsset.Services
{
    public partial class Database
    {
        public bool InsertAsset(Model.Asset asset)
        {
            try
            {
                asset.CreationTime = asset.UpdateTime = DateTime.Now;
                Instance.Connection.Insert(asset);
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }

            return true;
        }

        public List<Model.Asset> GetAssets()
        {
            try
            {
                return Instance.Connection.Table<Model.Asset>().ToList();

            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool UpdateAsset(Model.Asset asset)
        {
            try
            {
                asset.UpdateTime = DateTime.Now;

                Instance.Connection.Query<Model.Asset>(
                    "UPDATE Asset set Name=?, UpdateTime=?, StartTime=?, Endtime=?, EstimatedValue=?, AssetTypeId=?, AssetStatusId=?",
                    asset.Name, asset.UpdateTime, asset.StartTime, asset.EndTime, asset.EstimatedValue, asset.AssetTypeId, asset.AssetStatusId);

                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);

                return false;
            }
        }
    }
}