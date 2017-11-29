using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortal_Music.Contracts.DataContracts;
using WebPortal_Music.Contracts.Interfaces;
using WebPortal_Music.DAL.DataBase;

namespace WebPortal_Music.DAL.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        internal WebPortalContext db;
        internal DbSet<Music> dbSet;

        public MusicRepository(WebPortalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Music>();
        }
        public virtual IEnumerable<Music> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual Music GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Music entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Music entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Music entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Music entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
