
using AutoMapper;
using SgamApp.BLL.Interfaces;
using SgamApp.BLL.Models;

namespace SgamApp.BLL.Services
{
    public class GlossaryService<Entity, Model> : IGlossaryService<Model> where Entity : class where Model : class
    {
        private readonly IGlossaryRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public GlossaryService(IMapper mapper, IGlossaryRepository<Entity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Add(GlossaryModel entity)
        {
            var glossaryEntity = _mapper.Map<Entity>(entity);
            _repository.Add(glossaryEntity);
            _repository.SaveChanges();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public IEnumerable<GlossaryModel> GetAll()
        {
            var entities = _repository.GetAll();
            var models = _mapper.Map<IEnumerable<Model>>(entities);
            return models;
        }

        public GlossaryModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public GlossaryModel GetWord(string word)
        {
            throw new NotImplementedException();
        }

        public void Update(GlossaryModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
