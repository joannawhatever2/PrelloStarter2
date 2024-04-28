using System.ComponentModel.DataAnnotations;

namespace PrelloStarter3.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a project name.")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "You must set a due date!")]
        [Display(Name = "Due Date")]
        public DateTime DateDue { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
