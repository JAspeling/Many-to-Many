using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManytoMany.Models {
    public class Person {
        public Person() {
            PersonPerson = new Collection<PersonPerson>();
            Friends = new Collection<Person>();
        }

        public Person(string name, string surname) : this() {
            Name = name;
            Surname = surname;
        }

        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<PersonPerson> PersonPerson { get; set; }
        public ICollection<Person> Friends { get; set; }
    }
}
