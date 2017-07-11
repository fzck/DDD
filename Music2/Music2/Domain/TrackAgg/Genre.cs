using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Domain.TrackAgg
{
    public class Genre
    {
        public string Name { get; set; }
        public ICollection<TrackGenre> TrackGenres { get; set; }

        public Genre() { TrackGenres = new LinkedList<TrackGenre>();  }

        public Genre(string name)
        {
            Name = name;
        }
    }
}
