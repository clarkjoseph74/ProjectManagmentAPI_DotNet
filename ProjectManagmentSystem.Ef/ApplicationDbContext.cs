﻿
using Microsoft.EntityFrameworkCore;
using ProjectManagmentSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.EF;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {     
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskM> Tasks { get; set; }
    public DbSet<SubTask> SubTasks { get; set; }
}
