using SgamApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgamApp.DAL.Interfaces
{
    public interface IRepository<Entity> where Entity : class
    {
        IQueryable<Entity> GetAll();
        Entity GetById(int id);
        void Add(Entity entity); //solo per fase di creazione, non va esposta
        void Update(Entity entity);
        void Delete(int id); //solo per fase di creazione, non va esposta
        void SaveChanges();

    }
}
