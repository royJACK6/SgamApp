using Microsoft.EntityFrameworkCore;
using SgamApp.DAL.Entities;
using SgamApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgamApp.DAL.Repositories
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        private DbSet<Entity> _dbSet;
        private readonly SgamAppDbContext _context;

        public Repository(SgamAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }
        public void Add(Entity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var glossary = _dbSet.Find(id);
            if (glossary != null)
            {
                _dbSet.Remove(glossary);
                _context.SaveChanges();
            }
        }

        public IQueryable<Entity> GetAll()
        {
            return _dbSet;
        }

        public Entity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Entity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
