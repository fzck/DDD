using Music2.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Domain.ArtistAgg
{
    public interface IArtistRepository : IRepository <Artist, long>
    {
    }
}
