namespace ClonSpotifyBack.Models
{
    public class Music
    {
        public int Id { get; set; } 
        public int Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string LinkMusic { get; set; }
        public double Rating { get; set; }
        public int GenereId { get; set; }
        public Genere Genere { get; set; }  
    }
}
