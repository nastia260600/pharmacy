using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmasy.DB
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [ForeignKey ("Role")]
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
