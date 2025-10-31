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
    public class GlossaryRepository : IGlossaryRepository
    {
        private DbSet<Glossary> _dbSet;
        private readonly SgamAppDbContext _context;

        public GlossaryRepository(SgamAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Glossary>();
        }
        public void Add(Glossary entity)
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

        public IEnumerable<Glossary> GetAll()
        {
            return _dbSet.ToList();
        }

        public Glossary GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public Glossary GetByWord(string word)
        {
            return _dbSet.FirstOrDefault(g => g.BoomerWord == word || g.SlangWord == word);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Glossary entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
