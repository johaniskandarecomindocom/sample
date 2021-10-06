using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OB_Net_Core_Tutorial.Model
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        [JsonIgnore]
        public List<Book> Books { get; set; }

        public Author()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
