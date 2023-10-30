using System.ComponentModel.DataAnnotations;

namespace CRUDusingADO.Models
{
    public class Product
    {

        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string? Company{ get; set; }


       
       
        public string? ImageUrl { get; set; }
        [Required]
        public int Cid { get; set; }
        [ScaffoldColumn(false)]
        public string? Cname { get; set; }

        [ScaffoldColumn(false)]
        public int IsActive { set; get; }

    }
}
