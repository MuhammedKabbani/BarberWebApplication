using DataAccess.Abstract;
using DataAccess.Context.EFCore;
using Entities;

namespace DataAccess.Concrete
{
    public class DepartmentRepository : RepositoryBase<Department, AppDbContext>, IDepartmentRepository
    {
        public IEnumerable<User> GetUsersInDepartment(int departmentId)
        {
            return GetAllIncluded(d => d.Users).FirstOrDefault(d => d.Id == departmentId)?.Users ?? [];
        }
    }
}
