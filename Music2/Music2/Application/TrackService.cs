using Music2.Domain.ArtistAgg;
using Music2.Domain.TrackAgg;
using Music2.Helper;
using Music2.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Application
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;

        public TrackService(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository; 
        }

        public ICollection<TrackDto> GetAllTracks()
        {
            var tracks = _trackRepository.GetAll();

            if (!tracks.IsNullOrEmpty())
            {
                ICollection<TrackDto> tracksDto = new LinkedList<TrackDto>();
                TrackDto trackDto = null;

                foreach (Track track in tracks)
                {
                    trackDto = new TrackDto(track.Id, track.Title, track.DateReleased);

                    if (track.ArtistTracks.Count > 0)
                    {
                        foreach (ArtistTrack artistTrack in track.ArtistTracks)
                        {
                            trackDto.Artists.Add(new ArtistDto(artistTrack.Artist.Id,
                                                                artistTrack.Artist.DisplayName,
                                                                artistTrack.Artist.Firstname, artistTrack.Artist.Lastname,
                                                                new ArtistDetailsDto { StageName = artistTrack.Artist.ArtistDetails.StageName },
                                                                artistTrack.Artist.ConcurrencyStamp));
                        }
                    }

                    tracksDto.Add(trackDto);
                }
                return tracksDto;
            }

            return null;
        }

    }
}
