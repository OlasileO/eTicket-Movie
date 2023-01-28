using eTicket.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eTicket.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Actor Picture")]
        public string ProfilePictureUrl { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Actor Biography")]
        public string Biography { get; set; }
        public List<Actor_Movie>? Actor_Movies { get; set; }
    }
}
