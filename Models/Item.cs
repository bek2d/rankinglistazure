using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;


namespace MvcAppCollect.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public int CollectionId {get; set; }

        public string Owner { get; set; }

    }
}