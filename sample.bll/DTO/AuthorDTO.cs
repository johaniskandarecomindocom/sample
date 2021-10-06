using OB_Net_Core_Tutorial.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OB_Net_Core_Tutorial.DTO
{
    public class AuthorDTO
    {
        public Guid? Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public List<Book> Books { get; set; }
    }
}
