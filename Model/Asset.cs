using SQLite;

namespace MyAsset.Model
{
    [Table("Asset")]
    public class Asset
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int AssetTypeId { get; set; }
    }
}
