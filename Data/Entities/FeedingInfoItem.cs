using Marinel_ui.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marinel_ui.Data.Entities
{
    public class FeedingInfoItem : BaseEntity
    {
        public DateTime Date { get; set; }
        public decimal TotalCollected { get; set; }
        public int NumberOfStudents { get; set; }
        public decimal Revenue { get; set; }

        [ForeignKey("FeedingInfoItemId")]
        public ICollection<FeedingExpense> FeedingExpenses { get; set; }

        [NotMapped]
        public virtual Term Term { get; set; }
    }
}
