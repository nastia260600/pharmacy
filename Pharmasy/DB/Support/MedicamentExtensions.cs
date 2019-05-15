using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmasy.DB.Support
{
    public static class MedicamentExtensions
    {
        public static Medicament Copy(this Medicament original)
        {
            Medicament copy = new Medicament
            {
                HasContraindications = original.HasContraindications,
                Description = original.Description,
                Href = original.Href,
                Name = original.Name,
                Price = original.Price,
                Type = original.Type,
                Warning = original.Warning
            };
            return copy;
        }
    }
}
