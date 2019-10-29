using SQLite;
using System;

namespace MyAsset.Model
{
    [Table("Asset")]
    public class Asset
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal EstimatedValue { get; set; }
        public int AssetTypeId { get; set; }
        public int AssetStatusId { get; set; }
    }
}
