using eTicket.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTicket.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cinema Logo")]
        public string CinemaLogoUrl { get; set; }
        [Required]
        [Display(Name = "Cinema Name")]
        public string CinemaName { get; set; }
        [Required]
        [Display(Name = "Cinema Description")]
        public string Description { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
