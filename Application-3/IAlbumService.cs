﻿using Music3.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Application
{
    public interface IAlbumService
    {
        ICollection<AlbumDto> GetAllAlbums();
    }
}
