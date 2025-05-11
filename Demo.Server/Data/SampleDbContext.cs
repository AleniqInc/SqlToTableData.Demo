using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Demo.Server.Data;

/*
 * Don't forget to run migrations to create database:
 *      dotnet ef migrations add InitialCreate
 *      dotnet ef database update
 * 
 */

public partial class SampleDbContext : DbContext
{

    public SampleDbContext()
    {
    }

    public SampleDbContext(DbContextOptions<SampleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Query> Queries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("name=SQLite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Query>(entity =>
        {
            entity.ToTable("Query");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Sql).HasMaxLength(1000);
        });

        // seed some data
        modelBuilder.Entity<City>().HasData(
            new List<City>
               {
                    new City { Id = 1, Name = "Athens", Country = "Greece", Elevation = 70 },
                    new City { Id = 2, Name = "Barcelona", Country = "Spain", Elevation = 0 },
                    new City { Id = 3, Name = "Beijing", Country = "China", Elevation = 43 },
                    new City { Id = 4, Name = "Belgrade", Country = "Serbia", Elevation = 117 },
                    new City { Id = 5, Name = "Brasília", Country = "Brazil", Elevation = 1172 },
                    new City { Id = 6, Name = "Bratislava", Country = "Slovakia", Elevation = 124 },
                    new City { Id = 7, Name = "Bucharest", Country = "Romania", Elevation = 85 },
                    new City { Id = 8, Name = "Buenos Aires", Country = "Argentina", Elevation = 25 },
                    new City { Id = 9, Name = "Ciudad Juárez", Country = "Mexico", Elevation = 1140 },
                    new City { Id = 10, Name = "Cluj-Napoca", Country = "Romania", Elevation = 360 },
                    new City { Id = 11, Name = "Córdoba", Country = "Argentina", Elevation = 352 },
                    new City { Id = 12, Name = "Košice", Country = "Slovakia", Elevation = 206 },
                    new City { Id = 13, Name = "Madrid", Country = "Spain", Elevation = 650 },
                    new City { Id = 14, Name = "Mexico City", Country = "Mexico", Elevation = 2240 },
                    new City { Id = 15, Name = "Moscow", Country = "Russia", Elevation = 156 },
                    new City { Id = 16, Name = "Niš", Country = "Serbia", Elevation = 195 },
                    new City { Id = 17, Name = "Novi Sad", Country = "Serbia", Elevation = 80 },
                    new City { Id = 18, Name = "Patras", Country = "Greece", Elevation = 0 },
                    new City { Id = 19, Name = "Prizren", Country = "Serbia", Elevation = 450 },
                    new City { Id = 20, Name = "Rio de Janeiro", Country = "Brazil", Elevation = 0 },
                    new City { Id = 21, Name = "Rosario", Country = "Argentina", Elevation = 31 },
                    new City { Id = 22, Name = "Saint Petersburg", Country = "Russia", Elevation = 0 },
                    new City { Id = 23, Name = "São Paulo", Country = "Brazil", Elevation = 760 },
                    new City { Id = 24, Name = "Shanghai", Country = "China", Elevation = 0 },
                    new City { Id = 25, Name = "Thessaloniki", Country = "Greece", Elevation = 0 },
                    new City { Id = 26, Name = "Tijuana", Country = "Mexico", Elevation = 20 },
                    new City { Id = 27, Name = "Timișoara", Country = "Romania", Elevation = 90 },
                    new City { Id = 28, Name = "Valencia", Country = "Spain", Elevation = 0 },
                    new City { Id = 29, Name = "Vladivostok", Country = "Russia", Elevation = 0 },
                    new City { Id = 30, Name = "Xi'an", Country = "China", Elevation = 405 },
                    new City { Id = 31, Name = "Žilina", Country = "Slovakia", Elevation = 378 }
                }
            );

        modelBuilder.Entity<Query>().HasData(
            new List<Query>
                {
                    new Query { Id = 1, Sql = "SELECT ID, Name, Country, Elevation FROM City" },
                    new Query { Id = 2, Sql = "SELECT ID, Name, Country, Elevation FROM City WHERE Elevation > {0}" },
                    new Query { Id = 3, Sql = "SELECT ID, Name, Country, Elevation FROM City WHERE Elevation BETWEEN {0} AND {1}" } 
                }
            );

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
