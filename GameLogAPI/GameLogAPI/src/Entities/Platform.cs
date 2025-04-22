using System.ComponentModel.DataAnnotations;

namespace GameLogAPI.src.Entities {
    public class Platform {
        public Guid Id { get; set; }
        [Required] 
        public string Name { get; set; } = string.Empty;

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
