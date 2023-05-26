using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models
{
    public class User
    {
        [Key]
        public string? Username { get; set; }


        public byte[]? Password { get; set; }


        public byte[]? Hashkey { get; set; }
       

        public string? Phonenumber { get; set; }


        public string? name { get; set; }


        public int? age { get; set; }

        public string? Role { get; set; }


    }
}
