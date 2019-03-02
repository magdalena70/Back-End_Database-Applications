using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CodeFirst_Movies
{
    class Program
    {
        static void Main()
        {
            var context = new MoviesContext();
            var count = context.Countries.Count();
            Console.WriteLine(count);

        }
    }
}
