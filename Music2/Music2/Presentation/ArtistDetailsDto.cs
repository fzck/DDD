using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Presentation
{
    public class ArtistDetailsDto : BaseDto
    {
        public string StageName { get; set; }

        public ArtistDetailsDto() { }

        public ArtistDetailsDto(long id, string stageName)
        {
            Id = id;
            StageName = stageName;
        }
    }
}
