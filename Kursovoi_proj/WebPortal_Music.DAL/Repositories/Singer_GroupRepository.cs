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
    public class Singer_GroupRepository: ISinger_GroupRepository
    {
         internal WebPortalContext db;
        internal DbSet<Singer_Group> dbSet;

        public Singer_GroupRepository(WebPortalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Singer_Group>();
        }
        public virtual IEnumerable<Singer_Group> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual Singer_Group GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Singer_Group entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Singer_Group entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Singer_Group entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Singer_Group entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
