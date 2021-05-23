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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Letter> Letters { get; set; }
        public virtual DbSet<UserHistory> UserHistories { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

    }
}
