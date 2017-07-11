using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Presentation
{
    public class ArtistTrackDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }

        public ArtistTrackDto() { }

        public ArtistTrackDto(long id, string title, DateTime dateReleased)
        {
            Id = id;
            Title = title;
            DateReleased = dateReleased;
        }
    }
}
