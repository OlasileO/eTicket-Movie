using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTicket.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public Movie movie { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }    

        public Order order { get; set; }
    }
}
