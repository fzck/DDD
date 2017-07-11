using Music2.Domain.RecordAgg;
using Music2.Infrastructure.UnitOfWork;
using Music2.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Music2.Infrastructure.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly MainUnitOfWork _unitOfWork;

        public RecordRepository(MainUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MainUnitOfWork unitOfWork => _unitOfWork;

        public void Add(Record entity)
        {
            _unitOfWork._firstGenUnitOfWork.Records.Add(entity);
        }

        public IEnumerable<Record> Find(Specification<Record> spec)
        {
            throw new NotImplementedException();
        }

        public Record Get(long id)
        {
            return _unitOfWork._firstGenUnitOfWork.Records.FirstOrDefault(r => r.Id == id);
        }

        public void Modify(Record entity)
        {
            throw new NotImplementedException();
        }


        public void Remove(Record entity)
        {
            var track= _unitOfWork._secondGenUnitOfWork.Tracks.FirstOrDefault(t => t.Id == entity.Id);

            if (track != null)
            {
                _unitOfWork._secondGenUnitOfWork.Tracks.Remove(track);
                _unitOfWork._secondGenUnitOfWork.Commit();
            }

            _unitOfWork._firstGenUnitOfWork.Records.Remove(entity);
            _unitOfWork._firstGenUnitOfWork.Commit();

        }






    }
}
