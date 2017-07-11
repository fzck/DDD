using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Presentation
{
    public class ArtistDto : PersonDto
    {


        public ICollection<ArtistsTrackDto> Tracks { get;  }
        public virtual ArtistDetailsDto ArtistDetails { get; set; }

        public ArtistDto()
        {
            Tracks = new HashSet<ArtistsTrackDto>();
        }

        public ArtistDto(long id, string displayName, string firstname, string lastname, ArtistDetailsDto artistDetails, uint rowVersion)
        {
            Id = id;
            DisplayName = displayName;
            Firstname = firstname;
            Lastname = lastname;
            ArtistDetails = artistDetails;
            RowVersion = rowVersion;

            Tracks = new HashSet<ArtistsTrackDto>();
        }

    }
}
