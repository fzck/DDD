
using Music3.Domain.AlbumAgg;
using Music3.Domain.ArtistAgg;

using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Domain.TrackAgg
{
    public class Track : Entity
    {
        public string Title { get; set; }
        //public long Id { get; set; }
        public Artist Artist { get; set; }
        public Genre Genre { get; set; }
        //public string Genre { get; set; }
        public uint ConcurrencyStamp { get; set; }
        public uint Year { get; set; }
        public DateTime DateReleased { get; set; }
        public ICollection<TrackGenre> TrackGenres { get; set; }
        public ICollection<ArtistTrack> ArtistTracks { get; set; }
        public ICollection<AlbumTrack> AlbumTracks { get; set; }

        public Track()
        {
            ArtistTracks = new LinkedList<ArtistTrack>();
        }


        public Track(string title)
        {
            Title = title;
            ArtistTracks = new LinkedList<ArtistTrack>();
        }

        public Track(string title, long id, DateTime dateReleased)
        {
            Title = title;
            Id = id;
            DateReleased = dateReleased;

            ArtistTracks = new LinkedList<ArtistTrack>();
        }


        public Track(string title,  DateTime dateReleased)
        {
            Title = title;
            
            DateReleased = dateReleased;

            ArtistTracks = new LinkedList<ArtistTrack>();
        }

        public Track(string title, string genre, uint year)
        {
            Title = title;
            Genre.Name = genre;
            Year = year;

            ArtistTracks = new LinkedList<ArtistTrack>();
        }

        public virtual void AddToAlbum(Album album)
        {
            album.AddTrack(this);
        }

    }
}
