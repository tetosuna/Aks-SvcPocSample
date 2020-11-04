using System;
using System.ComponentModel.DataAnnotations;

namespace CommonLibrary.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
