using System;
using System.ComponentModel.DataAnnotations;

namespace SofiaTeachersOnline.Database.Models
{
    public class WannaBeUser
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        //[RegularExpression(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+", ErrorMessage = "Invalid email.")]
        public string Email { get; set; }

        //[RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNr { get; set; }

        public DateTime RecordedAt { get; set; }
    }
}
