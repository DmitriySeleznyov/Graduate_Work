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
    public class GenreRepository:IGenreRepository
    {
        internal WebPortalContext db;
        internal DbSet<Genre> dbSet;

        public GenreRepository(WebPortalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Genre>();
        }
        public virtual IEnumerable<Genre> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual Genre GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Genre entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Genre entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Genre entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Genre entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
