using DotnetApiBoilerplatev2._0.Core.Models.Common;

namespace DotnetApiBoilerplatev2._0.Core.Models.AccountDetails
{
    public class Accounts : BaseEntity
    {
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
