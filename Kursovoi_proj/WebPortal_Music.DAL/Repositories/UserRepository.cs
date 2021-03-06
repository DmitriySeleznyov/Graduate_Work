﻿using System;
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
        internal DbSet<User> dbSet;

        public UserRepository(WebPortalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<User>();
        }
        public virtual IEnumerable<User> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual User GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(User entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            User entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(User entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(User entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
