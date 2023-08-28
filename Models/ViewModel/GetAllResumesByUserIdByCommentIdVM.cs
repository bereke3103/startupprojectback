using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class GetAllResumesByUserIdByCommentIdVM
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedComment { get; set; } = DateTime.Now;
    }
}
