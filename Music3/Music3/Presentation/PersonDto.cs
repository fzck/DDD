using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Presentation
{
    public class PersonDto : PartyDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public PersonDto() { }

        public PersonDto(long id, string displayName, string firstname, string lastname, uint rowVersion)
        {
            Id = id;
            DisplayName = displayName;
            Firstname = firstname;
            Lastname = lastname;
            RowVersion = rowVersion;
        }
    }
}
