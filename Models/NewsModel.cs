using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NewsModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedNews { get; set; } = DateTime.Now;
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
