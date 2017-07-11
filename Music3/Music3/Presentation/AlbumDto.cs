using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Presentation
{
    public class AlbumDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }

        public ICollection<ArtistDto> Artists;

        public AlbumDto() { }

        public AlbumDto(long id, string title, DateTime dateReleased)
        {
            Id = id;
            Title = title;
            DateReleased = dateReleased;

            Artists = new LinkedList<ArtistDto>();
        }
    }
}
