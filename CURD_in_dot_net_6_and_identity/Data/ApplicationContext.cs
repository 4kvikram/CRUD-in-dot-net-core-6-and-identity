using CURD_in_dot_net_6_and_identity.Data.EntityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CURD_in_dot_net_6_and_identity.Data
{
    public class ApplicationContext: IdentityDbContext<IdentityUser> 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Project> Project { get; set; }

    }
}
