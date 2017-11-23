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
    public class UserRepository:IUsersRepository
    {
        internal WebPortalContext db;
        internal DbSet<Users> dbSet;

        public UserRepository(WebPortalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Users>();
        }
        public virtual IEnumerable<Users> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual Users GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Users entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Users entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Users entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Users entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
