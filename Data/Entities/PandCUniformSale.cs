﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Marinel_ui.Data.Entities
{
    public class PandCUniformSale : BaseEntity
    {
        public DateTime DatePaid { get; set; }
        public DateTime ReceivedDate { get; set; }
        public int CheckYardsQuantity { get; set; }
        public int PinkYardsQuantity { get; set; }
        public bool PaidInFull { get; set; }
        public bool Received { get; set; }
        public bool SeamstressPaid { get; set; }
        public string Notes { get; set; }
        public decimal TotalCollected { get; set; }


        //public int InventoryItemId { get; set; }
        public int StudentId { get; set; }

        //public virtual InventoryItem InventoryItem { get; set; }
        public virtual Student Student { get; set; }
    }
}


