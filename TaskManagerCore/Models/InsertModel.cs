using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerCore.Models
{
    public class InsertModel
    {
        public int projectId { get; set; }
        
        public string projectName { get; set; }
        public DateTime dateOfStart { get; set; }
        public int teamSize { get; set; }
        
    }
}
