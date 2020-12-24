using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace api.Model
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration):base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Person> People { get; set; }
    }
}