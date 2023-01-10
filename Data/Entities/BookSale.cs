using System;

namespace Marinel_ui.Data.Entities
{
    public class BookSale : BaseEntity
    {
        public DateTime Date { get; set; }
        public int NoOfBooksSold { get; set; }
        public decimal Revenue { get; set; }
        public int InventoryItemId { get; set; }

        public virtual InventoryItem InventoryItem { get; set; }
    }
}


