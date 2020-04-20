using System.ComponentModel.DataAnnotations;

namespace GenericHost
{
    class Actor
    {
        [Key]
        public int ActorID { get; set; }
        public string ActorName { get; set; }
    }
}
