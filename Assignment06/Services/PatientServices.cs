using Assignment06.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment06.Services
{
  

    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<IEnumerable<Patient>> GetAllPatientsAsync(CancellationToken cancellationToken = default)
            => _patientRepository.GetAllAsync(cancellationToken);

        public Task<Patient?> GetPatientByIdAsync(int patientId, CancellationToken cancellationToken = default)
            => _patientRepository.GetByIdAsync(patientId, cancellationToken);

        public Task<int> CreatePatientAsync(Patient patient, CancellationToken cancellationToken = default)
            => _patientRepository.AddAsync(patient, cancellationToken);

        public Task<bool> UpdatePatientAsync(Patient patient, CancellationToken cancellationToken = default)
            => _patientRepository.UpdateAsync(patient, cancellationToken);

        public Task<bool> DeletePatientAsync(int patientId, CancellationToken cancellationToken = default)
            => _patientRepository.DeleteAsync(patientId, cancellationToken);
    }

}
