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
        [BindProperty(SupportsGet = true)]
        public int? CollectionId { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public Collection Collection{ get; set; }
    }
}