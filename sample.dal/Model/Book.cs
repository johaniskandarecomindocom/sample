using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OB_Net_Core_Tutorial.Model
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [StringLength(500)]
        public string Title { get; set; }
        
        [StringLength(100)]
        public string ISBN { get; set; }

        public int TotalPages { get; set; }

        //public Guid AuthorId { get; set; }
        //public Author Author{ get; set; }


        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Book()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
