using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
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
