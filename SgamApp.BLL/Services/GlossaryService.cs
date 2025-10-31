
using AutoMapper;
using SgamApp.BLL.Interfaces;
using SgamApp.BLL.Models;
using SgamApp.DAL.Entities;
using SgamApp.DAL.Interfaces;

namespace SgamApp.BLL.Services
{
    public class GlossaryService : Service<Glossary, GlossaryModel>, IGlossaryService
    {
        private readonly IMapper _mapper;
        private readonly IGlossaryRepository _repository;
        public GlossaryService(IMapper mapper, IGlossaryRepository repository) : base(mapper, repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public GlossaryModel GetByWord(string word)
        {
            var entity = _repository.GetByWord(word);
            if(entity == null) {
                throw new ArgumentException("Word not found in glossary.");
            }
            return _mapper.Map<GlossaryModel>(entity);
        }
    }
}
