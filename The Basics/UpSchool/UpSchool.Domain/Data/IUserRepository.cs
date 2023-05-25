using UpSchool.Domain.Entities;

namespace UpSchool.Domain.Data
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);  

        Task<User> GetByIdAsync(Guid id,CancellationToken cancellationToken);

        Task<int> AddAsync(User user, CancellationToken cancellationToken);

        Task<int> UpdateAsync(User user, CancellationToken cancellationToken);

        Task<int> DeleteAsync(Guid id,CancellationToken cancellationToken);

    }
}
