using Android.Util;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System;

namespace MyAsset.Services
{
    public partial class Database
    {
        public bool InsertExpense(Model.Expense expense)
        {
            try
            {
                expense.CreationTime = DateTime.Now;
                Instance.Connection.Insert(expense);
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }

            return true;
        }

        public List<Model.Expense> GetExpensesByAssetId(int ID)
        {
            try
            {
                return Instance.Connection.Query<Model.Expense>("SELECT * FROM Expense WHERE AssetId = ?", ID);

            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool UpdateExpense(Model.Expense expense)
        {
            try
            {
                expense.UpdateTime = DateTime.Now;

                Instance.Connection.Query<Model.Expense>(
                    "UPDATE Expense set Name=?, Value=?, Time=?, UpdateTime=?, ExpenseSourceID=?, ExpenseStateId=?, AssetId=?",
                    expense.Name, expense.Value, expense.Time, expense.UpdateTime, expense.ExpenseSourceId, expense.ExpenseStateId, expense.AssetId);

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