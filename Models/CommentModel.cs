using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedComment { get; set; } = DateTime.Now;
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; }
        public int ResumeId { get; set; }
        public int AuthroId { get; set; }

        [ForeignKey("ResumeId")]
        public ResumeModel Resume { get; set; }

    }
}
