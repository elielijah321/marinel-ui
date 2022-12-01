using System;
using System.ComponentModel.DataAnnotations;

namespace Marinel_ui.Data.Entities
{
    public class LibraryBookRental
    {
        [Key]
        public int Id { get; set; }
        public int LibraryBookId { get; set; }
        public int StudentId { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime ExpextedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }

        public virtual LibraryBook LibraryBook { get; set; }
        public virtual Student Student { get; set; }
    }
}


