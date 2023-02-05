using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;

namespace DotnetApiBoilerplatev2._0.Core.Interfaces.AccountDetails
{
    public interface IRolesRepository : IGenericRepository<Roles>
    {
        Roles GetRolesByRoleId(int roleId);
    }
}
