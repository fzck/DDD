using Music3.Domain.PartyAgg;
using Music3.Domain.PersonAgg;
using Music3.Infrastructure.UnitOfWork;
using Music3.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Music3.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MainUnitOfWork _unitOFWork;

        public PersonRepository(MainUnitOfWork unitOfWork)
        {
            _unitOFWork = unitOfWork;
        }

        public MainUnitOfWork unitOfWork => _unitOFWork;

        public void Add(Person entity)
        {
            Party party = new Party(entity.DisplayName);
            _unitOFWork._firstGenUnitOfWork.Parties.Add(party);
            _unitOFWork._firstGenUnitOfWork.Commit();

            entity.Id = party.Id;

            _unitOFWork._secondGenUnitOfWork.Persons.Add(entity);
            _unitOFWork._secondGenUnitOfWork.Commit();
        }

        public IEnumerable<Person> Find(Specification<Person> spec)
        {
            throw new NotImplementedException();
        }

        public Person Get(long id)
        {
            return _unitOFWork._secondGenUnitOfWork.Persons.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _unitOFWork._firstGenUnitOfWork.Parties.AsNoTracking().ToList()
                  .Join(_unitOFWork._secondGenUnitOfWork.Persons, party => party.Id,
                        person => person.Id, (party, person) => InheritanceConstructor.ReConstructPerson(party, person));
        }

        public void Modify(Person entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Person entity)
        {
            var artist = _unitOFWork._thirdGenUnitOfWork.Artists.FirstOrDefault(a => a.Id == entity.Id);

            if (artist != null)
            {
                _unitOFWork._thirdGenUnitOfWork.Artists.Remove(artist);
                _unitOFWork._thirdGenUnitOfWork.Commit();
            }


            _unitOFWork._secondGenUnitOfWork.Persons.Remove(entity);
            _unitOFWork._secondGenUnitOfWork.Commit();

            var party = _unitOFWork._firstGenUnitOfWork.Parties.FirstOrDefault(p => p.Id == entity.Id);
            _unitOFWork._firstGenUnitOfWork.Remove(party);
            _unitOFWork._firstGenUnitOfWork.Commit();
        }
    }
}
