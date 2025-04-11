﻿using System.ComponentModel.DataAnnotations;

namespace GameLogAPI.src.Entities {
    public enum GameStatus {
        Wishlist,
        Planned,
        Playing,
        Completed,
        Dropped
    }

    public class Game {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Platform { get; set; } = string.Empty;
        [Required]
        public DateOnly ReleaseDate { get; set; }
        [Required]
        public GameStatus Status { get; set; } = GameStatus.Wishlist;
        [Range(1, 10)]
        public int? Rating { get; set; }
        public string? Review { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
    }
}
