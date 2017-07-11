using Music2.Domain.ArtistAgg;
using Music2.Domain.PartyAgg;
using Music2.Domain.PersonAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Infrastructure
{
    public static class InheritanceConstructor
    {
        public static Person ReconstructPerson(Party party, Person person)
        {
            person.DisplayName = party.DisplayName;
            return person;
        }

        public static Artist ReconstructArtist (Person person, Artist artist)
        {
            artist.DisplayName = person.DisplayName;
            artist.Firstname = person.Firstname;
            artist.Lastname = artist.Lastname;

            return artist;
        }

        internal static Person ReConstructPerson(Party party, Person person)
        {
            throw new NotImplementedException();
        }
    }
}
