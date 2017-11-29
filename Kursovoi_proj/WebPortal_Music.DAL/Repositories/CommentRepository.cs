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
    public class CommentRepository:ICommentsRepository
    {
        internal WebPortalContext db;
        internal DbSet<Comment> dbSet;

        public CommentRepository(WebPortalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Comment>();
        }
        public virtual IEnumerable<Comment> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual Comment GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Comment entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Comment entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Comment entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Comment entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
