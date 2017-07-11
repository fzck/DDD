using Music3.Domain.ArtistAgg;
using Music3.Domain.PartyAgg;
using Music3.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Music3.Specification;
using Music3.Domain.PersonAgg;

namespace Music3.Infrastructure.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MainUnitOfWork _unitOfWork;

        public ArtistRepository(MainUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MainUnitOfWork unitOfWork => _unitOfWork;

        public void Add(Artist entity)
        {
            Party party = new Party(entity.DisplayName);
            _unitOfWork._firstGenUnitOfWork.Parties.Add(party);
            _unitOfWork._firstGenUnitOfWork.Commit();

            Person person = new Person(entity.DisplayName, entity.Firstname, entity.Lastname);
            person.Id = party.Id;
            _unitOfWork._secondGenUnitOfWork.Persons.Add(person);
            _unitOfWork._secondGenUnitOfWork.Commit();

            entity.Id = person.Id;
            _unitOfWork._thirdGenUnitOfWork.Artists.Add(entity);
            _unitOfWork._thirdGenUnitOfWork.Commit();

        }

        public Artist Get(long id)
        {
            var artist = _unitOfWork._thirdGenUnitOfWork.Artists.Where(a => a.Id == id).Include(a => a.ArtistDetails).Include(a => a.ArtistTracks).FirstOrDefault();
            if (artist != null)
            {
                var party = _unitOfWork._firstGenUnitOfWork.Parties.Where(p => p.Id == id).FirstOrDefault();
                var person = _unitOfWork._secondGenUnitOfWork.Persons.Where(p => p.Id == id).FirstOrDefault();

                person = InheritanceConstructor.ReconstructPerson(party, person);
                artist = InheritanceConstructor.ReconstructArtist(person, artist);

                return artist;
            }

            return null;

        }

        public IEnumerable<Artist> GetAll()
        {
            /*
                return _unitOfWork._firstGenUnitOfWork.Parties.AsNoTracking().ToList()
                    .Join(_unitOfWork._secondGenUnitOfWork.Persons.AsNoTracking().ToList(), party => party.Id, person => person.Id,
                         (party, person) => InheritanceConstructor.ReConstructPerson(party, person))

                    .Join(_unitOfWork._thirdGenUnitOfWork.Artists.Include(a => a.ArtistDetails).Include(a => a.ArtistTracks).AsNoTracking().ToList(), person => person.Id, artist => artist.Id,
                        (person, artist) => InheritanceConstructor.ReconstructArtist(person, artist)).OrderBy(a => a.Id);
            */
            //   .Join(_unitOfWork._secondGenUnitOfWork.Tracks.AsNoTracking().ToList(), track => track.Id));

            return _unitOfWork._firstGenUnitOfWork.Parties.AsNoTracking().ToList()
               .Join(_unitOfWork._secondGenUnitOfWork.Persons.AsNoTracking().ToList(), party => party.Id, person => person.Id,
                    (party, person) => InheritanceConstructor.ReConstructPerson(party, person))
                .Join(_unitOfWork._thirdGenUnitOfWork.Artists.Include(a => a.ArtistDetails).Include(a => a.ArtistTracks).
                                                                                                ThenInclude(t => t.Track).AsNoTracking().
                                                                                            Include(a => a.ArtistAlbums).
                                                                                                ThenInclude(b => b.Album).AsNoTracking().
                                                                                            ToList(), person => person.Id, artist => artist.Id,
                                                                                                (person, artist) => InheritanceConstructor.ReconstructArtist(person, artist)).OrderBy(a => a.Id);


        }

        public void Modify(Artist entity)
        {
            var party = _unitOfWork._firstGenUnitOfWork.Parties.FirstOrDefault(p => p.Id == entity.Id);
            party.DisplayName = entity.DisplayName;
            _unitOfWork._firstGenUnitOfWork.Entry(party).State = EntityState.Modified;
            _unitOfWork._firstGenUnitOfWork.Commit();

            var person = _unitOfWork._secondGenUnitOfWork.Persons.FirstOrDefault(p => p.Id == entity.Id);
            person.Firstname = entity.Firstname;
            person.Lastname = entity.Lastname;
            _unitOfWork._secondGenUnitOfWork.Entry(person).State = EntityState.Modified;
            _unitOfWork._secondGenUnitOfWork.Commit();

            _unitOfWork._thirdGenUnitOfWork.Commit();

        }

        public void Remove(Artist entity)
        {
            _unitOfWork._thirdGenUnitOfWork.Remove(entity);
            _unitOfWork._thirdGenUnitOfWork.Commit();

            var person = _unitOfWork._secondGenUnitOfWork.Persons.FirstOrDefault(p => p.Id == entity.Id);
            _unitOfWork._secondGenUnitOfWork.Persons.Remove(person);
            _unitOfWork._secondGenUnitOfWork.Commit();

            var party = _unitOfWork._firstGenUnitOfWork.Parties.FirstOrDefault(p => p.Id == entity.Id);
            _unitOfWork._firstGenUnitOfWork.Parties.Remove(party);
            _unitOfWork._thirdGenUnitOfWork.Commit();
        }

        public IEnumerable<Artist> Find(Specification<Artist> spec)
        {
            var artists = _unitOfWork._thirdGenUnitOfWork.Artists.Where(spec.ToExpression());
            return artists;
        }

    }
}
