using System.Text.Json.Serialization;

namespace BookManagmentSystem.DTOs
{
    public class AuthorDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
   
        public List<string>? Books { get; set; }
        

    }
}
