using Microsoft.EntityFrameworkCore;
using kol2.Entities;
using kol2.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Services
{
    public class RepoS : IRepoS
    {
        private readonly RespositioryContex _respositioryContex;
        public RepoS(RespositioryContex respositioryContex)
        {
            _respositioryContex = respositioryContex;
        }

        public IQueryable<MusicianTrack> GetAllMusicTracksForMusician(int id)
        {
            return _respositioryContex.musicianTracks
                .Include(e => e.idMusician)
                .Where(e => e.idMusician == id);
        }

        public IQueryable<int> GetIdAlbums(int id)
        {
            var idTracks = _respositioryContex.musicianTracks.Where(e => e.idMusician == id)

            .Select(e => e.idTrack);

            var tracks = _respositioryContex.Track.Where(e => idTracks.Contains(e.idTrack));

            var idAlbums = tracks.Select(e => e.idMusicAlbum);

            return idAlbums;
        }

        IQueryable<Musician> IRepoS.GetMusicianById(int id)
        {
            return _respositioryContex.Musician.Where(e => e.idMusician == id);
        }
    }
}
