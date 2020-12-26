using System.ComponentModel.DataAnnotations.Schema;

namespace VesizleMvcCore.Identity.Entities
{
    [Table("Reminders")]
    public class Reminder : BaseEntity
    {
        public string Description { get; set; }
    }
}
