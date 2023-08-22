using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class UserUpdateVM
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string WorkPlace { get; set; }
        [Required]
        public string Stack { get; set; }
    }
}
