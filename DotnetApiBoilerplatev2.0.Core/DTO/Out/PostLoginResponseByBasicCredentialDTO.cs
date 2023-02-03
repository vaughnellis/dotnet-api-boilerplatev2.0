using DotnetApiBoilerplatev2._0.Core.Models.Accounts;

namespace DotnetApiBoilerplatev2._0.Core.DTO.Out
{
    public class PostLoginResponseByBasicCredentialDTO
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Roles> Roles { get; set; }
        public bool IsActive { get; set; }
    }
}
