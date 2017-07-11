using Music2.Domain.AlbumAgg;
using Music2.Infrastructure.UnitOfWork;
using Music2.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Music2.Infrastructure.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MainUnitOfWork _unitOfWork;

        public AlbumRepository(MainUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MainUnitOfWork unitOfWork => _unitOfWork;

        public void Add(Album entity)
        {
            _unitOfWork._secondGenUnitOfWork.Add(entity);

        }

        public IEnumerable<Album> Find(Specification<Album> spec)
        {
            throw new NotImplementedException();
        }

        public Album Get(long id)
        {
            return null;
        }

        public IEnumerable<Album> GetAll()
        {
            return _unitOfWork._secondGenUnitOfWork.Albums.Include(al => al.ArtistAlbums);
        }

        public void Modify(Album entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Album entity)
        {
            throw new NotImplementedException();
        }

    }
}
