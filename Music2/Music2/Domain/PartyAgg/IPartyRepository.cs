using Music2.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Domain.PartyAgg
{
    public interface IPartyRepository : IRepository<Party, long>
    {
    }
}
