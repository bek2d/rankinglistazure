using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace MvcAppCollect.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public int CollectionId { get; set; }
        //public int CollectionId { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public Collection Collection { get; set; }
    }
}