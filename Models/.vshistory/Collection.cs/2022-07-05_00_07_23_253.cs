using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MvcAppCollect.Data;
namespace MvcAppCollect.Models
{
    public class Collection
    {
        public int CollectionId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string UserId { get; set; }
        public double Likes { get; set; }
    }
}
