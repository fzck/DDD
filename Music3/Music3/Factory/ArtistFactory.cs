using Music3.Domain.ArtistAgg;
using Music3.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Factory
{
    public static class ArtistFactory
    {
        public static Artist CreateArtist(string displayname, string firstname, string lastname, ArtistDetailsDto artistDetailsDto )
        {
            Artist artist = new Artist(displayname, firstname, lastname);
            artist.CreateArtistDetails(artistDetailsDto.StageName);

            return artist;
        }
    }
}
