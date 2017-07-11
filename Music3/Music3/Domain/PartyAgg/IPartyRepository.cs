using Music3.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Domain.PartyAgg
{
    public interface IPartyRepository : IRepository<Party, long>
    {
    }
}
