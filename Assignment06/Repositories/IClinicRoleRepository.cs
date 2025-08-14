using System.Collections.Generic;
using Assignment06.Models;

namespace Assignment06.Repositories
{
    public interface IClinicRoleRepository
    {
        IEnumerable<ClinicRole> GetAll();
        ClinicRole GetById(int id);
        void Add(ClinicRole clinicRole);
        void Update(ClinicRole clinicRole);
        void Delete(int id);
    }
}
