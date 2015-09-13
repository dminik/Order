using System.ComponentModel.DataAnnotations;

namespace Orders.Models
{    
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public string Email { get; set; }        
    }
}