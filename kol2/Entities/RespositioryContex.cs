using Microsoft.EntityFrameworkCore;
using kol2.Entities.Models;

namespace kol2.Entities
{
    public class RespositioryContex : DbContext
    {
        public DbSet<Track> Track { get; set; }
        public DbSet<Musician> Musician { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<MusicianLabel> musicianLabels { get; set; }
        public DbSet<MusicianTrack> musicianTracks { get; set; }

        public RespositioryContex(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>(e =>
            {
                e.ToTable("Klient");
                e.HasKey(e => e.idTrack);

                e.Property(e => e.trackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.duration).IsRequired();
                e.Property(e => e.idMusicAlbum).IsRequired();

                e.HasData(
                    new Track
                    {
                        idTrack = 1,
                        trackName = "HighWay to Hell",
                        duration = 3.14f,
                        idMusicAlbum = 1
                    });
            });

            modelBuilder.Entity<Musician>(e =>
            {
                e.ToTable("Musician");
                e.HasKey(e => e.idMusician);

                e.Property(e => e.firstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.lastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.nickName).HasMaxLength(20).IsRequired();

                e.HasData(new Musician
                {
                    idMusician = 1,
                    firstName = "Mateusz",
                    lastName = "Kowalski",
                    nickName =  "gigaChad"
                });
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.ToTable("Album");
                e.HasKey(e => e.idAlbum);

                e.Property(e => e.albumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.publishDate).IsRequired();
                e.Property(e => e.idMusicLabel).IsRequired();

                e.HasData(new Album
                {
                    idAlbum = 1,
                    albumName = "kaka",
                    publishDate = new System.DateTime(2019, 5, 21),
                    idMusicLabel = 1
                });
            });
            modelBuilder.Entity<MusicianLabel>(e =>
            {
                e.ToTable("MusicianLabel");
                e.HasKey(e => e.idMusicLabel);

                e.Property(e => e.name).HasMaxLength(50).IsRequired();

                e.HasData(new MusicianLabel
                {
                    idMusicLabel = 1,
                    name = "SuperLabel"
                });
            });
            modelBuilder.Entity<MusicianTrack>(e =>
            {
                e.ToTable("MusicianTrack");
                e.HasKey(e => e.idTrack);
                e.HasAlternateKey(e => e.idMusician);

                e.HasData(new MusicianTrack
                {
                    idTrack = 1,
                    idMusician = 1
                });
            });
        }
    }
}
