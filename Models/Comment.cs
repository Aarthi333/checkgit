using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLINQProject.Models
{
    public class Comment
    {
        public int PostId { get; set; }
        public int Id { get; set; }
        public string CommenText { get; set; }
    }
}
