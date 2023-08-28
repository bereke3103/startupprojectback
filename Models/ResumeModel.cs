using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ResumeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Workplace { get; set; }
        [Required]
        public string Stack { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId ")]
        public UserModel User { get; set; }

    }
}
