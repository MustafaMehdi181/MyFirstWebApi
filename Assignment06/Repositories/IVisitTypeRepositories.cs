using System.Collections.Generic;
using Assignment06.Models;

namespace Assignment06.Repositories
{
    public interface IVisitTypeRepository
    {
        IEnumerable<VisitType> GetAll();
        VisitType GetById(int id);
        void Add(VisitType visitType);
        void Update(VisitType visitType);
        void Delete(int id);
    }
}
