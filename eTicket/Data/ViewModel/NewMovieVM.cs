using eTicket.Data.Base;
using eTicket.Data.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTicket.Models
{
    public class NewMovieVM
    {
        
        public int Id { get; set; } 
        [Display(Name ="Movie name")]
        [Required (ErrorMessage ="The Movie name is Required!")]
        public string Name { get; set; }

        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "Description is Required!")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is Required!")]
        public double Price { get; set; }

        [Display(Name = "Movie postel URl")]
        [Required(ErrorMessage = "Movie postel URl is Required!")]
        public string ImageUrl { get; set; }

        [Display(Name = "Movie start date")]
        [Required(ErrorMessage = "Movie Start date is Required!")]
        public DateTime Startdate { get; set; }

        [Display(Name = "Movie end date")]
        [Required(ErrorMessage = "Movie End date is Required!")]
        public DateTime Enddate { get; set; }

        [Display(Name = "Select category")]
        [Required(ErrorMessage = "Movie Category is Required!")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is Required!")]
        public List<int> ActorId { get; set; }

        [Display(Name = "Select cinema")]
        [Required(ErrorMessage = "Movie cinema is Required!")]
        public int CinemaId { get; set; }

        [Display(Name = "Select producer")]
        [Required(ErrorMessage = "Movie producer is Required!")]
        public int ProducerId { get; set; }
       
    }
}
