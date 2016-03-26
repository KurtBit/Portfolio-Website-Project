using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGGLinkedIn.Models
{
    public class Tag
    {
        public virtual int Id { get; set; }
        public virtual string Slug { get; set; }
        public virtual string Name { get; set; }

    }
}
