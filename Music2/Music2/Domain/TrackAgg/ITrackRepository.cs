using System;
using System.Collections.Generic;
using System.Text;
using Music2.Infrastructure.Repositories;
namespace Music2.Domain.TrackAgg
{
    public interface ITrackRepository : IRepository<Track, long>
    {
    }
}
