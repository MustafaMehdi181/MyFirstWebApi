using Assignment06.Models;
using Assignment06.Repositories;

namespace Assignment06.Services
{
   

    public class DoctorService : IDoctorServices
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Task<IEnumerable<Doctor>> GetAllDoctorsAsync(CancellationToken cancellationToken = default)
            => _doctorRepository.GetAllAsync(cancellationToken);

        public Task<Doctor?> GetDoctorByIdAsync(int doctorId, CancellationToken cancellationToken = default)
            => _doctorRepository.GetByIdAsync(doctorId, cancellationToken);

        public Task<int> CreateDoctorAsync(Doctor doctor, CancellationToken cancellationToken = default)
            => _doctorRepository.AddAsync(doctor, cancellationToken);

        public Task<bool> UpdateDoctorAsync(Doctor doctor, CancellationToken cancellationToken = default)
            => _doctorRepository.UpdateAsync(doctor, cancellationToken);

        public Task<bool> DeleteDoctorAsync(int doctorId, CancellationToken cancellationToken = default)
            => _doctorRepository.DeleteAsync(doctorId, cancellationToken);
    }


}
