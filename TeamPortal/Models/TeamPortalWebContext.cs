using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamPortal.Models
{
    public class TeamPortalWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<TeamPortal.Web.Models.TeamPortalWebContext>());

        public TeamPortalWebContext()
            : base("TeamPortalDB")
        {
            var adapter = this as IObjectContextAdapter;
            //adapter.ObjectContext.Connection.ConnectionString
        }

        public string WriteConnection()
        {
            var adapter = this as IObjectContextAdapter;
            return adapter.ObjectContext.Connection.ConnectionString;
        }

        public DbSet<TeamPortal.Models.Player> Players { get; set; }

        public DbSet<TeamPortal.Models.Team> Teams { get; set; }

        public DbSet<TeamPortal.Models.State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Team>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Player>().Ignore(m => m.PhotoToUpload);
            //modelBuilder.Entity<Player>().HasKey(m => new { m.Id, m.TeamId });
        }

    }
}