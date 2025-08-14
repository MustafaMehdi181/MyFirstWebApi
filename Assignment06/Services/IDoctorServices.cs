using Assignment06.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Assignment06.Services
{
    
    public interface IDoctorServices
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync(CancellationToken cancellationToken = default);
        Task<Doctor?> GetDoctorByIdAsync(int doctorId, CancellationToken cancellationToken = default);
        Task<int> CreateDoctorAsync(Doctor doctor, CancellationToken cancellationToken = default);
        Task<bool> UpdateDoctorAsync(Doctor doctor, CancellationToken cancellationToken = default);
        Task<bool> DeleteDoctorAsync(int doctorId, CancellationToken cancellationToken = default);
    }

}
