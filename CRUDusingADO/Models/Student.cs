using System.ComponentModel.DataAnnotations;

namespace CRUDusingADO.Models
{
    public class Student
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(40 , ErrorMessage = "Name contains Maximum 40 Char") ]
        public string Name { get; set; }

        [Required]
        
        public int Percentage { get;set; }

        [Required]
        public string City { get;set; }

    }
}
