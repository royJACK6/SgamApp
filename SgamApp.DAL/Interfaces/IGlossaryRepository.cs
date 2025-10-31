using SgamApp.DAL.Entities;

namespace SgamApp.DAL.Interfaces
{
    public interface IGlossaryRepository : IRepository<Glossary>
    {
        Glossary GetByWord(string word);
    }
}