using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartAPI.Entities
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price{ get; set; }

        [Required]
        public string ImgURL { get; set; }

    }
}
