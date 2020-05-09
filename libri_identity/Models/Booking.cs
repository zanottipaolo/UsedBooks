using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace libri_identity.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Required]
        [Key]
        public long Id_Booking { set; get; }
        [DataType(DataType.Date)]
        public string Start_Booking { set; get; }
        [DataType(DataType.Date)]
        public string End_Booking { set; get; }
        public string Title { set; get; }
        public string Isbn { set; get; }
        /// <summary>
        /// Student that reserved the book
        /// </summary>
        public string Student { set; get; }
        public long Id_Book { set; get; }
    }
}
