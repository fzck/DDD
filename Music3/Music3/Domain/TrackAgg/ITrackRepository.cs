using System;
using System.Collections.Generic;
using System.Text;
using Music3.Infrastructure.Repositories;
namespace Music3.Domain.TrackAgg
{
    public interface ITrackRepository : IRepository<Track, long>
    {
    }
}
