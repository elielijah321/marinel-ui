using System;

namespace Marinel_ui.Data.Entities
{
    public class AccountTransaction : BaseEntity
    {
        public DateTime Date { get; set; }
        public string AccountName { get; set; }
        public string ReasonForTransaction { get; set; }
        public decimal Amount { get; set; }
    }
}


