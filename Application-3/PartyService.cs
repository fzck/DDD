using Music3.Domain.PartyAgg;
using Music3.Presentation;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Music3.Helper;

namespace Music3.Application
{
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _partyRepository;

        public PartyService(IPartyRepository partyRepository)
        {
            _partyRepository = partyRepository;
        }

        public void CreateParty(PartyDto partyDto)
        {
            _partyRepository.Add(new Party(partyDto.DisplayName));
            _partyRepository.unitOfWork._firstGenUnitOfWork.Commit();
        }

        public void DeleteParty(long id)
        {
            var party = _partyRepository.Get(id);

            if (party == null)
            {

            }

            using (var transaction = _partyRepository.unitOfWork._firstGenUnitOfWork.Database.BeginTransaction())
            {
                var tr = transaction.GetDbTransaction();

                _partyRepository.unitOfWork._secondGenUnitOfWork.Database.UseTransaction(tr);
                _partyRepository.unitOfWork._thirdGenUnitOfWork.Database.UseTransaction(tr);

                _partyRepository.Remove(party);

                transaction.Commit();
            }
        }

        public ICollection<PartyDto> GetAllParties()
        {
            var parties = _partyRepository.GetAll();

            if (!parties.IsNullOrEmpty())
            {
                ICollection<PartyDto> partyDtos = new LinkedList<PartyDto>();
                PartyDto partyDto = null;

                foreach (Party party in parties)
                {
                    partyDto = new PartyDto();
                    partyDto.Id = party.Id;
                    partyDto.DisplayName = party.DisplayName;

                    partyDtos.Add(partyDto);
                }

                return partyDtos;
            }

            return null;
        }
    }
}
