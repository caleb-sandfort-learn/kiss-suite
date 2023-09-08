using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EhsUserWebApi.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("Identifier")]
        public int Identifier { get; set; }

        [Required]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required]
        [Column("Email")]
        public string Email { get; set; }

        public User()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
        }
    }
}
