using System.Collections.Generic;
using Assignment06.Models;

namespace Assignment06.Repositories
{
    public interface IVisitDetailRepository
    {
        IEnumerable<VisitDetail> GetAll();
        VisitDetail GetById(int id);
        void Add(VisitDetail visitDetail);
        void Update(VisitDetail visitDetail);
        void Delete(int id);
    }
}
