
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment06.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Patient?> GetByIdAsync(int patientId, CancellationToken cancellationToken = default);
        Task<int> AddAsync(Patient patient, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Patient patient, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int patientId, CancellationToken cancellationToken = default);
    }
}