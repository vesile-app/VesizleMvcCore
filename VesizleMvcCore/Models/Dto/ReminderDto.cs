using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VesizleMvcCore.Identity.Entities;

namespace VesizleMvcCore.Models.Dto
{
    public class ReminderDto
    {
        [Required]
        public int MovieId { get; set; }
        public string Description { get; set; }
    }
}
