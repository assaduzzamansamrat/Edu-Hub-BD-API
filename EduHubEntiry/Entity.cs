using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHubEntity
{
    public class Entity
    {
        public long Id { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? EditedBy { get; set; }
        public DateTime? EditedDate { get; set; }
        public string IpAddress { get; set; }
    }
}
