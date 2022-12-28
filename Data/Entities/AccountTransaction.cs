using System;
using System.ComponentModel.DataAnnotations;

namespace Marinel_ui.Data.Entities
{
    public class AccountTransaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string AccountName { get; set; }
        public string ReasonForTransaction { get; set; }
        public decimal Amount { get; set; }
    }
}


