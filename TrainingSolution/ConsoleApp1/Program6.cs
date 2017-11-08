using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program6
    {
        static void Main(string[] args)
        {
            using (FileStream fs = File.Create("Text.txt"))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write("Hello File!");
                }
            }

            Console.SetIn(new StreamReader("Input.txt"));
            StreamWriter sw2 = new StreamWriter("Output.txt");
            Console.SetOut(sw2);

            string str = Console.ReadLine();
            Console.WriteLine(str[str.Length - 1]);
            str = Console.ReadLine();
            Console.WriteLine(str[str.Length - 1]);
            str = Console.ReadLine();
            Console.WriteLine(str[str.Length - 1]);


            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach (FileInfo fi in di.GetFiles())
            {
                Console.WriteLine("{0}-{1}", fi.Name, fi.Length);
            }

            PeopleService ps = PeopleService.Default;
            PersonInfo[] people = ps.GetPeople();
            XmlSerializer serializer = new XmlSerializer(typeof(PersonInfo[]));
            using (FileStream fs2 = new FileStream("Text.txt", FileMode.Create))
            {
                serializer.Serialize(fs2, people);
                fs2.Flush();
            }

            using (FileStream fs3 = new FileStream("TextFile2.txt", FileMode.Open))
            {
                PersonInfo[] people2 = serializer.Deserialize(fs3) as PersonInfo[];
            }
            sw2.Flush();
            sw2.Close();

        }
    }

    [XmlType(TypeName = "person")]
    public class PersonInfo
    {
        [XmlElement(ElementName = "firstname")]
        public string Name { get; set; }
        [XmlElement(ElementName = "surname")]
        public string LastName { get; set; }

    }

    class PeopleService
    {
        public static PeopleService Default { get { return new PeopleService(); } }

        public PersonInfo[] GetPeople()
        {
            PersonInfo[] res = new PersonInfo[] {
                new PersonInfo(){ Name="n1", LastName="ln1" }
                ,new PersonInfo(){ Name="n2", LastName="ln2" }
                ,new PersonInfo(){ Name="n3", LastName="ln3" }
            };
            return res;
        }
    }
}