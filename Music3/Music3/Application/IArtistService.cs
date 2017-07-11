using Music3.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Application
{
    public interface IArtistService
    {
        void CreateArtist(ArtistDto artistDto);
        void DeleteArtist(long id);
        ICollection<ArtistDto> GetAllArtists();
        ArtistDto GetArtistById(long id);
        void ModifyArtist(long id, ArtistDto artistDto);
        void AddTrackToArtist(long id, TrackDto trackDto);

        void AddAlbumToArtist(long id, AlbumDto albumDto);

    }
}
