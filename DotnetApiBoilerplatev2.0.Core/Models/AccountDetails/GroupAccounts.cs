using DotnetApiBoilerplatev2._0.Core.Models.Common;

namespace DotnetApiBoilerplatev2._0.Core.Models.AccountDetails
{
    public class GroupAccounts : BaseEntity
    {
        public int AccountId { get; set; }
        public Accounts Accounts { get; set; }
        public int RoleId { get; set; }
        public Roles Roles { get; set; }
    }
}
