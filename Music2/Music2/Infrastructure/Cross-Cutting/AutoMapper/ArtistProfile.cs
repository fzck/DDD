using AutoMapper;
using Music2.Domain.AlbumAgg;
using Music2.Domain.ArtistAgg;
using Music2.Domain.TrackAgg;
using Music2.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Infrastructure.Cross_Cutting.AutoMapper
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistDto>();
            CreateMap<ArtistDetails, ArtistDetailsDto>();
            CreateMap<Track, TrackDto>();
            CreateMap<Album, AlbumDto>();
        }
    }
}
