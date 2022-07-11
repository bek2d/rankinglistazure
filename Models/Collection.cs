using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace MvcAppCollect.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Owner  { get; set; }

        //public ICollection<Item> Items { get; set; }

    }
}
