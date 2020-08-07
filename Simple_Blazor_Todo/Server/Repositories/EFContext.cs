using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Simple_Blazor_Todo.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Blazor_Todo.Server.Repositories
{
    public class EFContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<TodoItem> TodoItems { get; set; }

        public EFContext([NotNullAttribute] DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("TodoDB"));

    }
}
