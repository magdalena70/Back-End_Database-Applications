using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CodeFirst_Movies
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        public int? Stars { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public int? MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
