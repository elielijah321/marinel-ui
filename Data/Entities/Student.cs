using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marinel_ui.Data.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public int ClassId { get; set; }
        public DateTime DOB { get; set; }
        public string? ScholarshipType { get; set; }

        public virtual Class Class { get; set; }
    }
}
