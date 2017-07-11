using Music2.Domain.TrackAgg;
using Music2.Domain.ArtistAgg;
using Music2.Infrastructure.UnitOfWork;
using Music2.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Music2.Infrastructure.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly MainUnitOfWork _unitOfWork;

        public TrackRepository(MainUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MainUnitOfWork unitOfWork => unitOfWork;

        public void Add(Track entity)
        {
             
        }

        public IEnumerable<Track> Find(Specification<Track> spec)
        {
            throw new NotImplementedException();
        }

        public Track Get(long id)
        {
            return null;
        }

        public IEnumerable<Track> GetAll()
        {
            return _unitOfWork._secondGenUnitOfWork.Tracks.Include(t => t.ArtistTracks);
        }

        public void Modify(Track entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Track entity)
        {
            throw new NotImplementedException();
        }


    }
}
