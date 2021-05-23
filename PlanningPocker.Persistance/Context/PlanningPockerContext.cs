using Microsoft.EntityFrameworkCore;
using PlanningPocker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningPocker.Persistance.Context
{
    public class PlanningPockerContext: DbContext
    {
        public PlanningPockerContext()
        {
        }

        public PlanningPockerContext(DbContextOptions<PlanningPockerContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MISTER\\SQLEXPRESS;Initial Catalog=PLanningPockerDB;Integrated Security=True;");
            }
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Letter> Letters { get; set; }
        public virtual DbSet<UserHistory> UserHistories { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

    }
}
