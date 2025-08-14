using System.Collections.Generic;
using Assignment06.Models;
using Assignment06.Repositories;
using Assignment06.Services;

namespace Assignment06.Services
{
    public class VisitTypeService : IVisitTypeService
    {
        private readonly IVisitTypeRepository _repo;

        public VisitTypeService(IVisitTypeRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<VisitType> GetAll() => _repo.GetAll();
        public VisitType GetById(int id) => _repo.GetById(id);
        public void Add(VisitType visitType) => _repo.Add(visitType);
        public void Update(VisitType visitType) => _repo.Update(visitType);
        public void Delete(int id) => _repo.Delete(id);
    }
}
