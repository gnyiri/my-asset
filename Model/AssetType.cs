﻿using SQLite;

namespace MyAsset.Model
{
    [Table("AssetType")]
    public class AssetType
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
