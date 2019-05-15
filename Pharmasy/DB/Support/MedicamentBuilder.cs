using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmasy.DB.Support
{
    public class MedicamentBuilder
    {
        private Medicament item = new Medicament();

        public MedicamentBuilder IsMedication()
        {
            item.Type = MedicamentType.Medication;
            return this;
        }

        public MedicamentBuilder IsDietarySupplement()
        {
            this.item.Type = MedicamentType.DietarySupplement;
            return this;
        }

        public MedicamentBuilder WithHref(string href)
        {
            this.item.Href = href;
            return this;
        }

        public MedicamentBuilder WithNameAndDescription(string name, string description = null)
        {
            this.item.Name = name;
            this.item.Description = description;
            return this;
        }

        public MedicamentBuilder WithWarning(string warning)
        {
            this.item.Warning = warning;
            return this;
        }

        public MedicamentBuilder HasContraindications(string[] contraindicationsNames, PharmasyContext context)
        {
            var contraindications = from c in context.Medicaments
                                    where contraindicationsNames.Contains(c.Name)
                                    select c;
            //this.item.HasContraindications = ?? new List<Medicament>();
            this.item.HasContraindications.Concat(contraindications);
            return this;
        }

        public Medicament Build()
        {
            return this.item;
        }
    }
}
