using SgamApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgamApp.BLL.Interfaces
{
    public interface IService<Model> where Model : class
    {
        IEnumerable<Model> GetAll();
        Model GetById(int Id);
        void Add(Model model);
        void Update(Model model);
        void Delete(int id);
        void SaveChanges();
    }
}
