using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using libri_identity.Data;

namespace libri_identity.Models
{
    [Table("Book")]
    public class Book
    {
        [Required]
        [Key]
        public long Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Author { set; get; }
        [Required]
        public string Subject { set; get; }
        [Required]
        public string Course { set; get; }
        [Required]
        public string Class { set; get; }
        [Required]
        [Range(1455,2020,ErrorMessage = "Wrong year, enter a valid one (1455 - 2020)")]
        public int Year { set; get; }
        [Required]
        public string Publisher { set; get; }
        [Required]
        [StringLength(17)] // 13 digits + 4 '-'
        [RegularExpression("^(978|979)[\\-][0-9]{1,5}[\\-][0-9]{2,7}[\\-][0-9]{1,6}[\\-][0-9]{1}", 
            ErrorMessage = "ISBN not valid, (978-81-7525-766-5)")]
        public string Isbn { set; get; }
        /// <summary>
        /// Email of the student that added the book
        /// </summary>
        public string Name_Student { set; get; }
        /// <summary>
        /// If it's booked or not
        /// </summary>
        public long State { set; get; }
    }
}
