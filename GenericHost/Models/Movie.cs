using System.ComponentModel.DataAnnotations;

namespace GenericHost
{
    class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
