using System;
using SQLite;

namespace MyAsset.Model
{
    [Table("ExpenseType")]
    public class ExpenseType
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}