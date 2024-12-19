using DataAccess.Context.EFCore;
using Entities;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IRepositoryBase<User, AppDbContext>
    {
    }
}
