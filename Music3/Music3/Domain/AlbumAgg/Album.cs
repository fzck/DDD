
using Music3.Domain.ArtistAgg;
using Music3.Domain.TrackAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Domain.AlbumAgg
{
    public class Album : Entity
    {
        public string Title { get; set; }
        //public long Id { get; set; }
        public DateTime DateReleased { get; set; }
        public uint ConcurrencyStamp { get; set; }
        public string RecordLabel { get; set; }
        public uint YearReleased { get; set; }
        public ICollection<Track> TrackList { get; set; }
        public ICollection<AlbumTrack> AlbumTracks { get; set; }
        public ICollection<ArtistAlbum> ArtistAlbums { get; set; }

        public Album()
        { TrackList = new LinkedList<Track>(); }


        public Album(string albumTitle)
        {
            Title = albumTitle;
            TrackList = new LinkedList<Track>();
        }


        public Album(string albumTitle, long id, string recordLabel, uint yearReleased)
        {
            Title = albumTitle;
            Id = id;
            RecordLabel = recordLabel;
            YearReleased = yearReleased;
        }

        public Album(string albumTitle, uint year)
        {
            Title = albumTitle;
            YearReleased = year;

            TrackList = new LinkedList<Track>();
        }

        public virtual void AddTrack(Track track)
        {
            AlbumTracks.Add(new AlbumTrack { Album = this, Track = track });
        }






    }
}
