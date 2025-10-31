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
    public class GlossaryRepository : Repository<Glossary>, IGlossaryRepository
    {
        public GlossaryRepository(SgamAppDbContext context) : base(context)
        {
        }

        public Glossary GetByWord(string word)
        {
            var entity = GetAll().FirstOrDefault(g => g.BoomerWord == word || g.SlangWord == word);
            if(entity == null)
            {
                throw new ArgumentException("Word not found in glossary.");
            }
            return entity;
        }
    }
}
