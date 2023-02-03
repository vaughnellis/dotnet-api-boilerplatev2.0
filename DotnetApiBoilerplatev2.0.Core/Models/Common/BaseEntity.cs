namespace DotnetApiBoilerplatev2._0.Core.Models.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
