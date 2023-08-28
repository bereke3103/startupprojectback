using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel.Request
{
    public class RequestCreatingCommentVM
    {
        public int UserId { get; set; }
        public int ResumeId { get; set; }
        public string Comment { get; set; }
    }
}
