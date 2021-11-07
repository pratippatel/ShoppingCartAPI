using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartAPI.Entities
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }

    }
}
