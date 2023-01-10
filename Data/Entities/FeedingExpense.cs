using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marinel_ui.Data.Entities
{
    public class FeedingExpense : BaseEntity
    {
        public decimal ExpenseAmount { get; set; }
        public string ExpenseReason { get; set; }

        public int FeedingInfoItemId { get; set; }
    }
}
