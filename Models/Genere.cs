namespace ClonSpotifyBack.Models
{
    public class Genere
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Music> MusicsGenere { get; set; }
    }
}
