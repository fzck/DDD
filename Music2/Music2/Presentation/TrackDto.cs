using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Presentation
{
    public class TrackDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }

        public ICollection<ArtistDto> Artists;

        public TrackDto() { }

        public TrackDto(long id, string title, DateTime dateReleased)
        {
            Id = id;
            Title = title;
            DateReleased = dateReleased;

            Artists = new LinkedList<ArtistDto>();
        }
    }
}
