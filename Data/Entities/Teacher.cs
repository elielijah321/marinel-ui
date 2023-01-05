using System;

namespace Marinel_ui.Data.Entities
{
	public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
    }
}

