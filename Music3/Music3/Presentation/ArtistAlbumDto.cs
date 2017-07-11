using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Presentation
{
    public class ArtistAlbumDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }

        public ArtistAlbumDto() { }

        public ArtistAlbumDto(long id, string title, DateTime dateReleased)
        {
            Id = id;
            Title = title;
            DateReleased = dateReleased;
        }
    }
}
