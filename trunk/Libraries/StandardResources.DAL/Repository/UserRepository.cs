using StandardResources.DAL.Concretes;
using StandardResources.Entities.Domain;
using StandardResources.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardResources.DAL.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public ApplicationDbContext DataContext { get { return Context as ApplicationDbContext; } }

        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
