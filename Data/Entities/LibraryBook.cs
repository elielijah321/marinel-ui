using System;
using System.ComponentModel.DataAnnotations;

namespace Marinel_ui.Data.Entities
{
    public class LibraryBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
    }
}


