using Music2.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Application
{
    public interface IAlbumService
    {
        ICollection<AlbumDto> GetAllAlbums();
    }
}
