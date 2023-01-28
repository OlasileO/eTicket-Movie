using eTicket.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTicket.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Producer Picture")]
        public string ProfilePictureUrl { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Producer Biography")]
        public string Biography { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
