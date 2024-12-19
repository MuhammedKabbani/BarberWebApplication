using DataAccess.Abstract;
using DataAccess.Context.EFCore;
using Entities;

namespace DataAccess.Concrete
{
    public class UserRepository : RepositoryBase<User, AppDbContext>, IUserRepository
    {

    }
}
