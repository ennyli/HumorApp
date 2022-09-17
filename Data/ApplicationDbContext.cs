using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HumorApp.Models;

namespace HumorApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public object Gaate { get; internal set; }

        public DbSet<HumorApp.Models.Gaate> Gaate_1 { get; set; }

        public object Vits { get; internal set; }

        public DbSet<HumorApp.Models.Vits> Vits_1 { get; set; }
    }
}
