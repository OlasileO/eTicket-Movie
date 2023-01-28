using eTicket.Data.Base;
using eTicket.Data.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTicket.Models
{
    public class Movie:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Movie Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Movie Price")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Movie Image")]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Movie Start Date")]
        [DataType(DataType.Date)]
        public DateTime Startdate { get; set; }
        [Required]
        [Display(Name = "Movie End Date")]
        [DataType(DataType.Date)]
        public DateTime Enddate { get; set; }
        [Required]
        [Display(Name = "Movie Category")]
        public MovieCategory MovieCategory { get; set; }
        [Required]
        [Display(Name = "Actor in Movies")]
        public List<Actor_Movie> Actor_Movies { get; set; }

        [ForeignKey("CinemaId")]
        public int CinemaId { get; set; }
        [Required]
        [Display(Name = "Movie Cinema")]
        public Cinema Cinema { get; set; }

        [ForeignKey("ProduceId")]
        public int ProducerId { get; set; }
        [Required]
        [Display(Name = "Movie Producer")]
        public Producer producer { get; set; }
    }
}
