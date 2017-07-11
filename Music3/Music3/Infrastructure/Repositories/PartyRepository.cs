using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Music3.Domain.PartyAgg;
using Music3.Specification;
using Music3.Infrastructure.UnitOfWork;

namespace Music3.Infrastructure.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        private readonly MainUnitOfWork _unitOFWork;

        public PartyRepository(MainUnitOfWork unitOfWork)
        {
            _unitOFWork = unitOfWork;
        }

        public MainUnitOfWork unitOfWork => _unitOFWork;

        public void Add(Party entity)
        {
            _unitOFWork._firstGenUnitOfWork.Parties.Add(entity);
        }

        public IEnumerable<Party> Find(Specification<Party> spec)
        {
            throw new NotImplementedException();
        }

        public Party Get(long id)
        {
            return _unitOFWork._firstGenUnitOfWork.Parties.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Party> GetAll()
        {
            return _unitOFWork._firstGenUnitOfWork.Parties.AsNoTracking().AsEnumerable();
        }

        public void Modify(Party entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Party entity)
        {
            var person = _unitOFWork._secondGenUnitOfWork.Persons.FirstOrDefault(p => p.Id == entity.Id);

            if (person != null)
            {
                var artist = _unitOFWork._thirdGenUnitOfWork.Artists.FirstOrDefault(a => a.Id == entity.Id);

                if (artist != null)
                {
                    _unitOFWork._thirdGenUnitOfWork.Artists.Remove(artist);
                    _unitOFWork._thirdGenUnitOfWork.Commit();
                }

                _unitOFWork._secondGenUnitOfWork.Persons.Remove(person);
                _unitOFWork._secondGenUnitOfWork.Commit();
            }

            _unitOFWork._firstGenUnitOfWork.Parties.Remove(entity);
            _unitOFWork._firstGenUnitOfWork.Commit();
        }
    }
}
