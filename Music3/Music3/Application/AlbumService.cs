using Music3.Domain.AlbumAgg;
using Music3.Domain.ArtistAgg;
using Music3.Helper;
using Music3.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Application
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public ICollection<AlbumDto> GetAllAlbums()
        {
            var albums = _albumRepository.GetAll();

            if (!albums.IsNullOrEmpty())
            {
                ICollection<AlbumDto> albumsDto = new LinkedList<AlbumDto>();
                AlbumDto albumDto = null;

                foreach(Album album in albums)
                {
                    albumDto = new AlbumDto(album.Id, album.Title, album.DateReleased);

                    if(album.ArtistAlbums.Count > 0)
                    {
                        foreach (ArtistAlbum artistAlbum in album.ArtistAlbums)
                        {
                            albumDto.Artists.Add(new ArtistDto(artistAlbum.Artist.Id,
                                                                artistAlbum.Artist.DisplayName,
                                                                artistAlbum.Artist.Firstname, artistAlbum.Artist.Lastname,
                                                                new ArtistDetailsDto { StageName = artistAlbum.Artist.ArtistDetails.StageName },
                                                                artistAlbum.Artist.ConcurrencyStamp));

                        }
                    }

                    albumsDto.Add(albumDto);

                }
                return albumsDto;

            }
            return null;
        }

    }
}
