using System;

namespace Marinel_ui.Data.Entities
{
    public class Expense : BaseEntity
    {
        public ExpenseType Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
    }
}
