using Music3.Domain.ArtistAgg;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Music3.Presentation;
using Music3.Factory;
using Music3.Helper;
using Music3.Domain.TrackAgg;
using Music3.Domain.AlbumAgg;

namespace Music3.Application
{

    public class ArtistService : IArtistService
    {

        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public void CreateArtist(ArtistDto artistDto)
        {
            using (var transaction = _artistRepository.unitOfWork.BeginTransaction(3))
            {
                _artistRepository.Add(ArtistFactory.CreateArtist(artistDto.DisplayName,
                                                                 artistDto.Firstname,
                                                                 artistDto.Lastname,
                                                                 artistDto.ArtistDetails));
            }
        }

        public void DeleteArtist(long id)
        {
            var artist = _artistRepository.Get(id);
            
            if (artist == null)
            {
                throw new ArgumentException($"author {id} does not exist.");
            }

            using (var transaction = _artistRepository.unitOfWork.BeginTransaction(3))
            {
                _artistRepository.Remove(artist);
                transaction.Commit();
            }
        }

        public ICollection<ArtistDto> GetAllArtists()
        {
            var artists = _artistRepository.GetAll();
            return !artists.IsNullOrEmpty() ? _mapper.Map<ICollection<ArtistDto>>(artists) : null;

        }

        

        public void AddTrackToArtist(long id, TrackDto trackDto)
        {
            var artist = _artistRepository.Get(id);

            if (artist == null)
            {
                throw new ArgumentException($"author {id} does not exist.");
            }

            Track track = artist.CreateTrack(trackDto.Title, trackDto.DateReleased);

            artist.AddTrack(track);

            _artistRepository.unitOfWork._thirdGenUnitOfWork.Commit();
        }

        public void AddAlbumToArtist(long id, AlbumDto albumDto)
        {
            var artist = _artistRepository.Get(id);

            if (artist == null)
            {
                throw new ArgumentException($"author {id} does not exist.");
            }

            Album album = artist.CreateAlbum(albumDto.Title);

            artist.AddAlbum(album);

            _artistRepository.unitOfWork._thirdGenUnitOfWork.Commit();

        }

        public void ModifyArtist(long id, ArtistDto artistDto)
        {
            var artist = _artistRepository.Get(id);

            if (artist == null)
            {
                throw new ArgumentException($"author {id} does not exist.");
            }

            artist.ChangeDisplayName(artistDto.DisplayName);
            artist.ChangFirstname(artistDto.Firstname);
            artist.ChangeLastname(artistDto.Lastname);
            artist.ChangeStageName(artistDto.ArtistDetails.StageName);

            using(var t = _artistRepository.unitOfWork.BeginTransaction(3))
            {
                _artistRepository.Modify(artist);
                t.Commit();
            }

        }

        public ArtistDto GetArtistById(long id)
        {
            var artist = _artistRepository.Get(id);

            if (artist == null)
            {
                throw new ArgumentException($"author {id} does not exist.");
            }

            return _mapper.Map<ArtistDto>(artist);

        }
    }
}
