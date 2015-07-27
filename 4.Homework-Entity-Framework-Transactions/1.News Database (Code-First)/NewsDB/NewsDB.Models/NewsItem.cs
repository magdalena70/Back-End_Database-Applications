using System;
using System.ComponentModel.DataAnnotations;

namespace NewsDB.Models
{
    public class NewsItem
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [ConcurrencyCheck]
        public string Content { get; set; }
    }
}
