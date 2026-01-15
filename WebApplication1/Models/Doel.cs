namespace WebApplication1.Models  // ← VERANDER DIT
{
    public class Doel
    {
        public required string Titel { get; set; }
        public required string Beschrijving { get; set; }
        public required int Minuten { get; set; }
        public required string Beloning { get; set; }
    }
}