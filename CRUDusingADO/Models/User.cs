using System.ComponentModel.DataAnnotations;

namespace CRUDusingADO.Models
{
    public class User
    {

        public int Id { set; get; }
        [Required]

        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string? Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        [Required]
       

        public string? Email { set;get; }
    }
}
