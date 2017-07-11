using Music2.Domain.AlbumAgg;
using Music2.Domain.PersonAgg;
using Music2.Domain.RecordAgg;
using Music2.Domain.TrackAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Domain.ArtistAgg
{
    public class Artist : Person
    {
       
        public DateTime YearDebuted { get; set; }
        //public virtual ICollection<Track> Tracks { get; set; }
        //public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<ArtistTrack> ArtistTracks { get; set; }
        public virtual ICollection<ArtistAlbum> ArtistAlbums { get; set; }
        public virtual ArtistDetails ArtistDetails { get; set; }
        

        public uint Year { get; set; }


        public Artist()
        {
            ArtistTracks = new LinkedList<ArtistTrack>();
            ArtistAlbums = new LinkedList<ArtistAlbum>();
            //Albums = new LinkedList<Album>();
            //Tracks = new LinkedList<Track>();
        }

        public Artist(string stageName)
        {
            ArtistDetails.StageName = stageName;
            ArtistTracks = new LinkedList<ArtistTrack>();
            ArtistAlbums = new LinkedList<ArtistAlbum>();
        }

        public Artist(string displayName, string firstname, string lastname)
        {
            DisplayName = displayName;
            Firstname = firstname;
            Lastname = lastname;
        }

        public virtual void AddTrack(Track track)
        {
            ArtistTracks.Add(new ArtistTrack { Artist = this, Track = track });
        }

        public virtual void AddAlbum(Album album)
        {
            ArtistAlbums.Add(new ArtistAlbum { Artist = this, Album = album });
        }


        public virtual Track CreateTrack(string title)
        {
            return new Track(title);
        }

        public virtual Track CreateTrack(string title, string genre, uint year)
        {
            return new Track(title, genre, year);
        }

        public virtual Track CreateTrack(string title, DateTime dateReleased)
        {
            return new Track(title, dateReleased);
        }

        public Album CreateAlbum(string title)
        {
            return new Album(title);
        }

        public virtual void AddTrackToArtist(Track track)
        {
            ArtistTracks.Add(new ArtistTrack { Artist = this, Track = track });
        }

        public virtual void ChangeStageName(string newStageName)
        {
            ArtistDetails.StageName = newStageName;
        }

        public virtual void AddTrackToAlbum(Track track, Album album)
        {
            album.AddTrack(track);
        }

        public virtual void CreateArtistDetails (string stageName)
        {
            ArtistDetails.StageName = stageName;
        }


    }
}
