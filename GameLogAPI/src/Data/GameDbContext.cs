﻿using GameLogAPI.src.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameLogAPI.src.Data {
    public class GameDbContext : DbContext {
        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>(builder => {
                builder.HasOne(e => e.Platform)
                    .WithMany(e => e.Games)
                    .HasForeignKey(e => e.IdPlatform);
            });

            modelBuilder.Entity<Platform>(builder => {
                builder.HasIndex(e => e.Name)
                .IsUnique();
            });
        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
