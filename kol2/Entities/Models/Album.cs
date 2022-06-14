namespace kol2.Entities.Models
{
    public class Album
    {
        public int idAlbum { get; set; }
        public string albumName { get; set; }
        public DateTime publishDate { get; set; }
        public int idMusicLabel { get; set; }
    }
}
