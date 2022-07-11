using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace MvcAppCollect.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double NumberOfItems { get; set; }
        public string Topic { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}
