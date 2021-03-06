using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace MvcAppCollect.Models
{
    public class Collection
    {
        public int CollectionId { get; set; }
  
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double NumberOfItems { get; set; }
        public string Topic { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
