﻿using Microsoft.EntityFrameworkCore;

namespace Sober.Infrastructure.Persistence
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(PortfolioDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
