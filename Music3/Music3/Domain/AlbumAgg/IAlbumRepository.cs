using Music3.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Domain.AlbumAgg
{
    public interface IAlbumRepository : IRepository<Album, long>
    {
    }
}
