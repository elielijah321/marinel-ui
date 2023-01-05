using System;

namespace Marinel_ui.Data.Entities
{
    public class InventoryItem : BaseEntity
    {
        public string Name { get; set; }
        public int InventoryTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal CostPerUnit { get; set; }
        public decimal SellingPrice { get; set; }
        public virtual InventoryType InventoryType { get; set; }
    }
}
