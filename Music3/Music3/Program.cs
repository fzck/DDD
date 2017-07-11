using Music3.Domain.ArtistAgg;
using Music3.Domain.TrackAgg;
using System;

namespace Music3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ppali ppali pihae like cherry bomb");
            Artist x = new Artist();
            x.CreateArtistDetails("gdYB");
            x.AddTrackToArtist(new Domain.TrackAgg.Track("shhh"));

            Track t = x.CreateTrack("liang");

            
            


            Console.WriteLine(x.ArtistDetails.StageName);
            Console.WriteLine(x.ArtistTracks.Count);

            Console.ReadLine();
        }
    }
}