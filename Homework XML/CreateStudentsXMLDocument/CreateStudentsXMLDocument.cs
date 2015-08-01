using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreateStudentsXMLDocument
{
    class CreateStudentsXMLDocument
    {
        static void Main()
        {
            var studentsXml = new XElement("students",
                new XAttribute("culture", "en-US"),
                new XElement("student",
                    new XElement("name", "Maria Petrova"),
                    new XElement("gender", "female"),
                    new XElement("birthDate", DateTime.Parse("1992-05-12")),
                    new XElement("email", "maria@abv.bg"),
                    new XElement("university", "SoftUni"),
                    new XElement("specialty", "IT"),
                    new XElement("facultyNumber", 12345),
                    new XElement("exams",
                        new XElement("exam", 
                            new XElement("name", "DB Apps"),
                            new XElement("dateTaken", DateTime.Parse("2015-07-28")),
                            new XElement("grade", 5)
                        ),
                        new XElement("exam",
                            new XElement("name", "C# Advanced"),
                            new XElement("dateTaken", DateTime.Parse("2015-06-20")),
                            new XElement("grade", 4)
                        )
                    ),
                    new XElement("endorsements",
                        new XElement("endorsement",
                            new XElement("author", "Dimitar Georgiev"),
                            new XElement("authorEmail", "dimitargeorgiev@abv.bg"),
                            new XElement("date", DateTime.Parse("2015-07-29")),
                            new XElement("text", "Some interesting text...")
                        )
                    )
                ),
                new XElement("student",
                    new XElement("name", "Todor Vasilev"),
                    new XElement("gender", "male"),
                    new XElement("birthDate", DateTime.Parse("1992-05-12")),
                    new XElement("phone", "+359899123123"),
                    new XElement("email", "todor@mail.bg"),
                    new XElement("university", "SoftUni"),
                    new XElement("specialty", "Frond-End"),
                    new XElement("exams",
                        new XElement("exam", 
                            new XElement("name", "JavaScript Apps"),
                            new XElement("dateTaken", DateTime.Parse("2015-07-28")),
                            new XElement("grade", 6)
                        )
                    )
                )
            );

            Console.WriteLine(studentsXml);
            //studentsXml.Save("../../../students.xml");
        }
    }
}
