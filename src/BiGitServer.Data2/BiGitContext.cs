using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.IO;


namespace BiGitServer.Data2
{
    //DbContext
    public class BiGitContext:DbContext /*IdentityDbContext<User, ApplicationRole, Guid>*/
    {
        private string _connectionString;
        public BiGitContext(string connectionString) : this()
        {
            _connectionString = connectionString;
        }
        public BiGitContext(DbContextOptions<BiGitContext> options) : base(options)
        {
        }
        public BiGitContext():base()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    Directory.GetCurrentDirectory();
        //    if (!string.IsNullOrEmpty(_connectionString))
        //    {
        //        optionsBuilder.UseSqlite(_connectionString);
        //    }        
        
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(x => x.Id);
                //entity.Property(x => x.Id).HasMaxLength(36);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");
            });
        }
    }
    public class User/*: IdentityUser<Guid>*/
    {      
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  string Id { get; set; }
        public  string Name { get; set; }
        public  string Surname { get; set; }
        public  string Password { get; set; }
        public  string Email { get; set; }
        public  string Role { get; set; }
    }
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
    public class ApplicationRole /*: IdentityRole<Guid>*/
    {
    }
}
