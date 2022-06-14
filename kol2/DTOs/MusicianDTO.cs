namespace kol2.DTOs
{
    public class MusicianDTO
    {
        public int IdMusician { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string nickname { get; set; }

        public List<TrackDTO> Tracks { get; set; }
    }
}
