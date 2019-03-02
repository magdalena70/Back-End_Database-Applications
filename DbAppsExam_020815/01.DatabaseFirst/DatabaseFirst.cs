using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DatabaseFirst
{
    class DatabaseFirst
    {
        static void Main()
        {
            // list all characters' names.
            var context = new DiabloEntities();
            var characterNames = context.Characters.Select(ch => ch.Name);
            foreach (var characterName in characterNames)
            {
                Console.WriteLine(characterName);
            }
        }
    }
}
