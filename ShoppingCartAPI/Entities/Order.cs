using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ShoppingCartAPI.Entities
{
    [Table("Order", Schema = "dbo")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DefaultValue(0)]
        public int ProductId { get; set; }

        [Required]
        [DefaultValue(0)]
        public int UserId { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Quantity { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool HasPlaced { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
