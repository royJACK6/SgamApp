using SgamApp.BLL.Models;

namespace SgamApp.BLL.Interfaces
{
    public interface IGlossaryService<Model> where Model : class
    {
        IEnumerable<GlossaryModel> GetAll();
        GlossaryModel GetById(int Id);
        GlossaryModel GetWord(string word);
        void Add(GlossaryModel entity);
        void Update(GlossaryModel entity);
        void Delete(int id);
    }
}
