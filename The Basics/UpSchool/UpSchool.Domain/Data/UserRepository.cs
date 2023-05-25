using SQLite;
using System.Linq.Expressions;
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


        //Expression<Func<>
        public Task<int> DeleteAsync(Expression<Func<User,bool>> predicate, CancellationToken cancellationToken)
        {
            return _database.Table<User>().DeleteAsync(predicate);
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
