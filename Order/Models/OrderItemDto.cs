using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Orders.Models
{
    public class OrderItemDto
    {
        /// <summary>
        /// Data transfer object for <see cref="TodoItem"/>
        /// </summary>
        public OrderItemDto() { }

        public OrderItemDto(OrderItem item)
        {
            Id = item.Id;
            Text = item.Text;
            Email = item.Email;
            Status = item.Status.ToString();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public String Status { get; set; }

        [Required]
        public string Email { get; set; }

        public OrderItem ToEntity()
        {
            return new OrderItem
            {
                Id = Id,
                Text = Text,
                Email = Email,
                Status = (OrderStatus) Enum.Parse(typeof(OrderStatus), Status, true),
            };
        }
    }
}
