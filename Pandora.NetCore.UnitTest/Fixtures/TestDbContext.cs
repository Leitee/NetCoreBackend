﻿using Microsoft.EntityFrameworkCore;
using Pandora.NetStandard.Data.Dals;

namespace Pandora.NetCore.UnitTest
{
    public class TestDbContext : SchoolDbContext
    {
        public TestDbContext(DbContextOptions options) : base(null, options, true)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(nameof(TestDbContext));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);//user superclass default initialization
            //Add custome data entity for test purpose
        }
    }
}
