using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Resource
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public TypeOfResource TipeOfResource { get; set; }

        [Required]
        [MaxLength(50)]
        public string Url { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
