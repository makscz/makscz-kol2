using kol2.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Services
{
    public interface IRepoS
    {
        IQueryable<Musician> GetMusicianById(int id);

        IQueryable<MusicianTrack> GetAllMusicTracksForMusician(int id);

        IQueryable<int> GetIdAlbums(int id);

    }
}
