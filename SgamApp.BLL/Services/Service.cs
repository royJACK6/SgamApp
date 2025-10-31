using AutoMapper;
using SgamApp.BLL.Interfaces;
using SgamApp.BLL.Models;
using SgamApp.DAL.Interfaces;

namespace SgamApp.BLL.Services
{
    public class Service<Entity, Model> : IService<Model> where Entity : class where Model : class
    {
        private readonly IRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public Service(IMapper mapper, IRepository<Entity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Add(Model model)
        {
            var newEntity = _mapper.Map<Entity>(model);
            _repository.Add(newEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(Model model)
        {
            var entity = _mapper.Map<Entity>(model);
            _repository.Update(entity);
        }

        IEnumerable<Model> IService<Model>.GetAll()
        {
            var entities = _repository.GetAll();
            var models = _mapper.Map<IEnumerable<Model>>(entities);
            return models;
        }

        Model IService<Model>.GetById(int Id)
        {
            var entity = _repository.GetById(Id);
            var model = _mapper.Map<Model>(entity);
            return model;
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}
