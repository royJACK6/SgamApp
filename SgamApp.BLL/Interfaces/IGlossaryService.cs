using SgamApp.BLL.Models;

namespace SgamApp.BLL.Interfaces
{
    public interface IGlossaryService : IService<GlossaryModel>
    {
        GlossaryModel GetByWord(string word);
    }
}
