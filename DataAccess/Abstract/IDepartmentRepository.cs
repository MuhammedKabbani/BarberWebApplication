using DataAccess.Context.EFCore;
using Entities;

namespace DataAccess.Abstract
{
    public interface IDepartmentRepository : IRepositoryBase<Department, AppDbContext>
    {
        IEnumerable<User> GetUsersInDepartment(int departmentId);
    }
}
