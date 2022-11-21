using System;
using System.ComponentModel.DataAnnotations;

namespace Marinel_ui.Data.Entities
{
	public class Teacher
	{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
    }
}

