using System.Collections.Generic;
using Assignment06.Models;
using Assignment06.Repositories;

namespace Assignment06.Services
{
    public class ClinicRoleService : IClinicRoleService
    {
        private readonly IClinicRoleRepository _clinicRoleRepository;

        public ClinicRoleService(IClinicRoleRepository clinicRoleRepository)
        {
            _clinicRoleRepository = clinicRoleRepository;
        }

        public IEnumerable<ClinicRole> GetAll() => _clinicRoleRepository.GetAll();
        public ClinicRole GetById(int id) => _clinicRoleRepository.GetById(id);
        public void Add(ClinicRole clinicRole) => _clinicRoleRepository.Add(clinicRole);
        public void Update(ClinicRole clinicRole) => _clinicRoleRepository.Update(clinicRole);
        public void Delete(int id) => _clinicRoleRepository.Delete(id);
    }
}
