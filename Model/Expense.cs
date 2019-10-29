using System;
using SQLite;

namespace MyAsset.Model
{
    [Table("Expense")]
    public class Expense
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime Time { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreationTime { get; set; }
        public int ExpenseSourceId { get; set; }
        public int ExpenseStateId { get; set; }
        public int AssetId { get; set; }
    }
}