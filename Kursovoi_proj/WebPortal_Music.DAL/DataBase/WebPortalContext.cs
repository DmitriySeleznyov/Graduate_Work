using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortal_Music.Contracts.DataContracts;

namespace WebPortal_Music.DAL.DataBase
{
   public class WebPortalContext: DbContext
    {
        public WebPortalContext()
        :base("WebPortalContext")
        {
            //System.Data.Entity.Database.SetInitializer<WebPortalContext>(new WebPortal_Initializer());
            //Database.Initialize(true);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Singer_Group> Singer_Groups { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
