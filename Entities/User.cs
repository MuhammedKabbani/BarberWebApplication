using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User : IdentityUser, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
