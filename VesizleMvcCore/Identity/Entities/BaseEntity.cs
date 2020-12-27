using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VesizleMvcCore.Identity.Entities
{
    public class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
        }
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string UserId { get; set; }

        [Required]
        public virtual VesizleUser User { get; set; }
    }
}
