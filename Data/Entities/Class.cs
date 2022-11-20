﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marinel_ui.Data.Entities
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PinkAndCheckUniformPrice { get; set; }

        [ForeignKey("ClassId")]
        public virtual ICollection<Student> Students { get; set; }
    }
}
