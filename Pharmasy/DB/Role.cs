using System.ComponentModel.DataAnnotations;

namespace Pharmasy.DB
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
