using SQLite;
using UpSchool.Domain.Entities;

namespace UpSchool.Domain.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public UserRepository(SQLiteAsyncConnection database)
        {
            var dbPath = Path.Combine("C:\\Users\\tugbayazici\\Desktop", "upschool.db");

            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<User>().Wait();
        }

        public Task<int> AddAsync(User user, CancellationToken cancellationToken)
        {

            return _database.InsertAsync(user);
        }

        public Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _database.Table<User>().DeleteAsync(x=> x.Id == id);
        }


        public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _database.Table<User>().FirstOrDefaultAsync(x=> x.Id == id);
        }

        public Task<int> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            return _database.UpdateAsync(user);
        }

        Task<List<User>> IUserRepository.GetAllAsync(CancellationToken cancellationToken)
        {
            return _database.Table<User>().ToListAsync();
        }
    }
}
