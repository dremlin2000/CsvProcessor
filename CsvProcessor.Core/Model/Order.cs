using Data.Repository.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScvProcessor.Core.Model
{
    [Table("Orders")]
    public class Order : EntityBase<Guid>
    {
        [Column("Item_Count")]
        public int ItemCount { get; set; }
        [Column("Item_Name")]
        public string ItemName { get; set; }
        [Column("Price")]
        public double Price { get; set; }
    }
}
