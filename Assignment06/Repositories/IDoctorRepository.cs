using Assignment06.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment06.Repositories
{
   

    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Doctor?> GetByIdAsync(int doctorId, CancellationToken cancellationToken = default);
        Task<int> AddAsync(Doctor doctor, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Doctor doctor, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int doctorId, CancellationToken cancellationToken = default);
    }

}
