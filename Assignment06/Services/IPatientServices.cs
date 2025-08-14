using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment06.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync(CancellationToken cancellationToken = default);
        Task<Patient?> GetPatientByIdAsync(int patientId, CancellationToken cancellationToken = default);
        Task<int> CreatePatientAsync(Patient patient, CancellationToken cancellationToken = default);
        Task<bool> UpdatePatientAsync(Patient patient, CancellationToken cancellationToken = default);
        Task<bool> DeletePatientAsync(int patientId, CancellationToken cancellationToken = default);
    }

}
