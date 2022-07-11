using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace MvcAppCollect.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public int CollectionFK { get; set; }
        //[ForeignKey("CollectionId")]
        //public int CollectionId { get; set; }
        //[BindProperty(SupportsGet = true)]

        //public Collection Collection { get; set; }
    }
}