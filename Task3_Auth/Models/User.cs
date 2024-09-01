using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Task3_Auth.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }  
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set;}
        public bool IsAcrive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
