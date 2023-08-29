using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel.Request
{
    public class ResponseCreatingCommentVM
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedComment { get; set; } = DateTime.Now;
    }
}
