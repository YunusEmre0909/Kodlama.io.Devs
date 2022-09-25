using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("id");
                a.Property(p => p.Name).HasColumnName("name");
                a.HasMany(p => p.Technologies);
            });

            ProgrammingLanguage[] programmingLanguagesEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesEntitySeeds);

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k=>k.Id);
                a.Property(t => t.Id).HasColumnName("id");
                a.Property(t => t.ProgrammingLanguageId).HasColumnName("programmingLanguageId");
                a.Property(t => t.Name).HasColumnName("name");
                a.HasOne(t=>t.ProgrammingLanguage);
            });
            Technology[] technologyEntitySeeds = {new(1,1,"ASP.Net"),new(2,1,"WPF"),new(3,2,"Spring") };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);

            modelBuilder.Entity<SocialLink>(a=>
            {
                a.ToTable("SocialLinks").HasKey(k => k.Id);
                a.Property(s => s.Id).HasColumnName("id");
                a.Property(s=>s.GithubLink).HasColumnName("githubLink");
            });

            SocialLink[] secialLinkEntitySeeds = {new(1, "https://github.com/YunusEmre0909"),new(2, "https://github.com/YunusEmre09") };
            modelBuilder.Entity<SocialLink>().HasData(secialLinkEntitySeeds);
        }
    }
}
