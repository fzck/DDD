using Music2.Domain.PartyAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Domain.PersonAgg
{
    public class Person : Party
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Name { get { return $"{Firstname} {Lastname}"; } }

        public Person() { }

        public Person(string displayName, string firstname, string lastname)
        {
            DisplayName = displayName;
            Firstname = firstname;
            Lastname = lastname;
            
        }

        public virtual void ChangFirstname(string newFirstname)
        {         
            Firstname = newFirstname;
        }

        public virtual void ChangeLastname(string newLastname)
        {
            Lastname = newLastname;
        }
    }
}
