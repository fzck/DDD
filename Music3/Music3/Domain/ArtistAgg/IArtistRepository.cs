using Music3.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Domain.ArtistAgg
{
    public interface IArtistRepository : IRepository <Artist, long>
    {
    }
}
