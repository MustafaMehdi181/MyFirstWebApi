using System.Collections.Generic;
using Assignment06.Models;

namespace Assignment06.Services
{
    public interface IVisitDetailService
    {
        IEnumerable<VisitDetail> GetAllVisitDetails();
        VisitDetail GetVisitDetailById(int id);
        void AddVisitDetail(VisitDetail visitDetail);
        void UpdateVisitDetail(VisitDetail visitDetail);
        void DeleteVisitDetail(int id);
    }
}
