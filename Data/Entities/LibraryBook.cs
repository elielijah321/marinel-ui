using System;

namespace Marinel_ui.Data.Entities
{
    public class LibraryBook : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
    }
}


