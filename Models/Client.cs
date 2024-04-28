using System.ComponentModel.DataAnnotations;

namespace PrelloStarter3.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; }

        public string EmailAddress { get; set; }
    }
}
