using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program4
    {
        static void Main1(string[] args)
        {
            Person[] personArray = new Person[] {
                new Person("saxeli1", "gvari1"),
                new Person("saxeli2", "gvari2"),
                new Person("saxeli2", "gvari21"),
                new Person("saxeli3", "gvari3"),
                new Person("saxeli4", "gvari4")
            };

            People p = new People(personArray);

            foreach (Person person in p)
            {
                Console.WriteLine(person.ToString());
            }

            Dictionary<Person, decimal> employees = new Dictionary<Person, decimal>();
            employees.Add(personArray[0], 100);
            employees.Add(personArray[1], 200);
            employees.Add(personArray[2], 300);

            Console.WriteLine("{0}'s salary is:{1}", personArray[2], employees[personArray[2]]);

            var query = from t in p
                        where t.FirstName.EndsWith("2")
                        select new { Name = t.ToString() };

            foreach (var r in query)
            {
                Console.WriteLine(r.Name);
            }

            foreach (var r in p.Where(e => e.FirstName.EndsWith("2")).Select(e1=> new { Name = e1.ToString() }))
            {
                Console.WriteLine(r.Name);
            }


            Console.ReadLine();
        }


    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string fname, string lname)
        {
            FirstName = fname;
            LastName = lname;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.ToString() == person2.ToString();
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !(person1 == person2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Person)
                return this == (obj as Person);

            return base.Equals(obj);
        }
    }

    class People : IEnumerable<Person>
    {
        private Person[] _PersonArray;

        public People(Person[] personArray)
        {
            this._PersonArray = personArray;
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return new PeopleEnum(_PersonArray);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PeopleEnum(_PersonArray);
        }
    }

    class PeopleEnum : IEnumerator<Person>
    {
        private Person[] _PersonArray;
        private int _Index;

        public PeopleEnum(Person[] personArray)
        {
            _Index = -1;
            this._PersonArray = personArray;
        }

        public Person Current
        {
            get { return _PersonArray[_Index]; }
        }

        object IEnumerator.Current
        {
            get { return _PersonArray[_Index]; }
        }

        public bool MoveNext()
        {
            _Index++;
            return _Index < _PersonArray.Length;
        }

        public void Reset()
        {
            _Index = -1;
        }

        public void Dispose()
        {
            
        }
    }

}
