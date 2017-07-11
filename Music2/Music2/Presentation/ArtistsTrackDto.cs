using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Presentation
{
    public class ArtistsTrackDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }

        public ArtistsTrackDto() { }

        public ArtistsTrackDto(long id, string title, DateTime dateReleased)
        {
            Id = id;
            Title = title;
            DateReleased = dateReleased;
        }
    }
}
