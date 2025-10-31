using SgamApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgamApp.DAL.Interfaces
{
    public interface IGlossaryRepository
    {
        IEnumerable<Glossary> GetAll();
        Glossary GetById(int id);
        Glossary GetByWord(string word);
        void Add(Glossary entity); //solo per fase di creazione, non va esposta
        void Update(Glossary entity);
        void Delete(int id); //solo per fase di creazione, non va esposta
        void SaveChanges();
        
    }
}
