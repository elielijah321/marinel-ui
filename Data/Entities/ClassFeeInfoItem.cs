using Marinel_ui.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marinel_ui.Data.Entities
{
    public class ClassFeeInfoItem : BaseEntity
    {
        public DateTime Date { get; set; }
        public int NumberEnrolled { get; set; }
        public int NumberPaid { get; set; }
        public decimal AmountReceived { get; set; }

        [NotMapped]
        public virtual Term Term { get; set; }
    }
}
