using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class ResumeListByIdGetVM
    {
        public int Id { get; set; }
        public string Nickname { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Workplace { get; set; }

        public string Stack { get; set; }

    }
}
