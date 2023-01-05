using System;
using System.ComponentModel.DataAnnotations;

namespace Marinel_ui.Data.Entities
{
	public class BaseEntity
	{
        [Key]
        public int Id { get; set; }
    }
}

