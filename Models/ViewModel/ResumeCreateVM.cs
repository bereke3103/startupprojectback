using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class ResumeCreateVM
    {
        [Required]
        public int UserId { get; set; }
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

    }
}
