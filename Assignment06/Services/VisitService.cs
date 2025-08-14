using System.Collections.Generic;
using Assignment06.Models;
using Assignment06.Repositories;

namespace Assignment06.Services
{
    public class VisitDetailService : IVisitDetailService
    {
        private readonly IVisitDetailRepository _visitDetailRepository;

        public VisitDetailService(IVisitDetailRepository visitDetailRepository)
        {
            _visitDetailRepository = visitDetailRepository;
        }

        public IEnumerable<VisitDetail> GetAllVisitDetails()
        {
            return _visitDetailRepository.GetAll();
        }

        public VisitDetail GetVisitDetailById(int id)
        {
            return _visitDetailRepository.GetById(id);
        }

        public void AddVisitDetail(VisitDetail visitDetail)
        {
            _visitDetailRepository.Add(visitDetail);
        }

        public void UpdateVisitDetail(VisitDetail visitDetail)
        {
            _visitDetailRepository.Update(visitDetail);
        }

        public void DeleteVisitDetail(int id)
        {
            _visitDetailRepository.Delete(id);
        }
    }
}
