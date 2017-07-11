using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Music3.Domain.ArtistAgg;
using Music3.Domain.TrackAgg;
using Music3.Domain.AlbumAgg;

namespace Music3.Infrastructure.UnitOfWork
{
    public class ThirdGenUnitOfWork : DbContext, IUnitOfWork
    {
        public DbSet<ArtistTrack> ArtistTracks { get; set; }
        public DbSet<ArtistAlbum> ArtistAlbums { get; set; }
        public DbSet<AlbumTrack> AlbumTracks { get; set; }
        public DbSet <TrackGenre> TrackGenres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public ThirdGenUnitOfWork(DbContextOptions<ThirdGenUnitOfWork> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<Album>(album =>
            {
                album.HasKey("Id");
                album.Property("Id").HasColumnName("id");
                album.Property("Title").HasColumnName("title");
                album.Property("YearReleased").HasColumnName("year_released");
                album.Property(p => p.ConcurrencyStamp).ForNpgsqlHasColumnName("xmin").ForNpgsqlHasColumnType("xid").ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                album.ToTable("album");
            });

            builder.Entity<Track>(track =>
            {
                track.HasKey("Id");
                track.Property("Id").HasColumnName("id");
                track.Property("Title").HasColumnName("title");
                track.Property("DateReleased").HasColumnName("date_released");
                track.Property(p => p.ConcurrencyStamp).ForNpgsqlHasColumnName("xmin").ForNpgsqlHasColumnType("xid").ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                track.ToTable("track");
            });


            builder.Entity<Artist>(artist =>
            {
                artist.HasKey("Id");
                artist.Property("Id").HasColumnName("id");
                artist.HasOne(a => a.ArtistDetails).WithOne(a => a.Artist).HasForeignKey<ArtistDetails>(ad => ad.ArtistId);               
                artist.Property(p => p.ConcurrencyStamp).ForNpgsqlHasColumnName("xmin").ForNpgsqlHasColumnType("xid").ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                artist.Ignore("DisplayName");
                artist.Ignore("FirstName");
                artist.Ignore("LastName");
                artist.ToTable("artist");
            });

            builder.Entity<ArtistDetails>(artistDetails =>
            {
                artistDetails.HasKey("ArtistId");
                artistDetails.Property("ArtistId").HasColumnName("artist_id");
                artistDetails.Property("StageName").HasColumnName("pen_name");
                artistDetails.ToTable("artist_details");
            });

            builder.Entity<ArtistTrack>(artist_track =>
            {
                artist_track.HasKey(ad => new { ad.ArtistId, ad.TrackId });
                artist_track.Property("ArtistId").HasColumnName("artist_id");
                artist_track.Property("TrackId").HasColumnName("track_id");
                artist_track.HasOne(at => at.Artist).WithMany(a => a.ArtistTracks).HasForeignKey(at => at.ArtistId);
                artist_track.HasOne(at => at.Track).WithMany(a => a.ArtistTracks).HasForeignKey(at => at.TrackId);
                artist_track.ToTable("artist_track");
                
            });


            builder.Entity<ArtistAlbum>(artist_album =>
            {
                artist_album.HasKey(ald => new { ald.ArtistId, ald.AlbumId });
                artist_album.Property("ArtistId").HasColumnName("artist_id");
                artist_album.Property("AlbumId").HasColumnName("album_id");
                artist_album.HasOne(aa => aa.Artist).WithMany(a => a.ArtistAlbums).HasForeignKey(aa => aa.ArtistId);
                artist_album.HasOne(aa => aa.Album).WithMany(a => a.ArtistAlbums).HasForeignKey(aa => aa.AlbumId);
                artist_album.ToTable("artist_album");

            });

            builder.Entity<TrackGenre>(track_genre =>
            {
                track_genre.HasKey(td => new { td.TrackId, td.GenreId });
                track_genre.Property("TrackId").HasColumnName("track_id");
                track_genre.Property("GenreId").HasColumnName("genre_id");
                track_genre.HasOne(tg => tg.Track).WithMany(t => t.TrackGenres).HasForeignKey(tg => tg.TrackId);
                track_genre.HasOne(tg => tg.Genre).WithMany(t => t.TrackGenres).HasForeignKey(tg => tg.GenreId);
                track_genre.ToTable("track_genre");

            });

            builder.Entity<AlbumTrack>(album_track =>
            {
                album_track.HasKey(atd => new { atd.AlbumId, atd.TrackId });
                album_track.Property("AlbumId").HasColumnName("album_id");
                album_track.Property("TrackId").HasColumnName("track_id");
                album_track.HasOne(alt => alt.Album).WithMany(aT => aT.AlbumTracks).HasForeignKey(alt => alt.AlbumId);
                album_track.HasOne(alt => alt.Track).WithMany(aT => aT.AlbumTracks).HasForeignKey(alt => alt.TrackId);
                album_track.ToTable("album_track");
            });



            base.OnModelCreating(builder);
        }

        public void Commit()
        {
            SaveChanges();
        }

        public void Rollback()
        {
            Commit();
        }


    }
}
