﻿using System;
using backend.src.GOD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.src.GOD.DataAccess.Context
{
    public class GODContext : DbContext
    {
        public GODContext(DbContextOptions<GODContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Round> Rounds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Round>()
                .HasOne(r => r.Game)
                .WithMany(g => g.Rounds)
                .HasForeignKey(r => r.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Player>()
              .HasIndex(p => p.PlayerName)
              .IsUnique();
        }
    }
}
