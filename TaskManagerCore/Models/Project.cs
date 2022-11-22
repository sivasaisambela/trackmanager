using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerCore.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime DateOfStart { get; set; }
        public int TeamSize { get; set; }
       
    }
}
