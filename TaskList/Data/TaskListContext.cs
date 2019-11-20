using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskList.Models;

    public class TaskListContext : DbContext
    {
        public TaskListContext (DbContextOptions<TaskListContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<myTask>().ToTable("Task");
        }

        public DbSet<TaskList.Models.myTask> Task { get; set; }
    }
