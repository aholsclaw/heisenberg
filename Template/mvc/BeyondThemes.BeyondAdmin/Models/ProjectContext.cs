﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class ProjectContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProjectContext() : base("name=ProjectContext")
        {
        }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.ProjectPerson> ProjectPersons { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.Cost> Costs { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.Resource> Resources { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.CostType> CostTypes { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.PhaseType> PhaseTypes { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.ResourceType> ResourceTypes { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.Status> Status { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.ProjectPhase> ProjectPhases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectPerson>()
                .HasRequired(p => p.Role);

            modelBuilder.Entity<ProjectPhase>()
                .HasRequired(t => t.PhaseType);

            modelBuilder.Entity<ProjectTask>()
                .HasRequired(p => p.ProjectTaskType);

            modelBuilder.Entity<Cost>()
                .HasRequired(c => c.CostType);

            modelBuilder.Entity<Resource>()
                .HasRequired(r => r.ResourceType);

            modelBuilder.Entity<Budget>()
                .HasRequired(r => r.PhaseType);
        }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.ProjectTask> ProjectTasks { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.ProjectTaskType> ProjectTaskTypes { get; set; }

        public System.Data.Entity.DbSet<BeyondThemes.BeyondAdmin.Models.Budget> Budgets { get; set; }
      
    }
}
