using DotnetApiBoilerplatev2._0.Core.Interfaces.AccountDetails;
using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;

namespace DotnetApiBoilerplatev2._0.Infrastructure.Repositories.AccountDetails
{
    public class RolesRepository : GenericRepository<Roles>, IRolesRepository
    {
        public RolesRepository(DataContext context)
            : base(context)
        { }

        public Roles GetRolesByRoleId(int roleId)
        {
            return this.GetById(roleId).Result;
        }
    }
}
