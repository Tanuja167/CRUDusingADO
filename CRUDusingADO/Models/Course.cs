using System.ComponentModel.DataAnnotations;

namespace CRUDusingADO.Models
{
    public class Course
    {

        public int Id { set;get; }
        [Required]
        public string Name { set;get; }

        [Required]
        public int Duration { set; get; }
        [Required]

        public int Fees { set; get; }   

    }
}
