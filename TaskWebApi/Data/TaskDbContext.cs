using Microsoft.EntityFrameworkCore;
using System;
using TaskWebApi.Models;

namespace TaskWebApi.Data
{
    public class TaskDbContext:DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        //table add from class
        public DbSet<tblItem> tblItems { get; set;}
        public DbSet<tblOrderDetails> tblOrderDetails { get; set;}
        public DbSet<tblOrderMaster>  tblOrderMasters { get; set;}

    }
}
