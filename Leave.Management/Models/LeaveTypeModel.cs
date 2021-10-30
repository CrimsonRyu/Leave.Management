using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave.Management.Models
{
    public class DetailsLeaveTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class CreateLeaveTypeModel
    {
        [Required]
        public string Name { get; set; }
    }
}
