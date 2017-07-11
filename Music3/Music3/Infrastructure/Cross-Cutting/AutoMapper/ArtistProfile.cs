using AutoMapper;
using Music3.Domain.AlbumAgg;
using Music3.Domain.ArtistAgg;
using Music3.Domain.TrackAgg;
using Music3.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Infrastructure.Cross_Cutting.AutoMapper
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
