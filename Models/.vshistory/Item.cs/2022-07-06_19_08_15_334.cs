using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace MvcAppCollect.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [Required]

        public string Name { get; set; }


        public int CollectionId { get; set; }

    }
}