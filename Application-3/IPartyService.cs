using Music3.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Application
{
    public interface IPartyService
    {
        void CreateParty(PartyDto partyDto);
        void DeleteParty(long id);
        ICollection<PartyDto> GetAllParties();
        

    }
}
