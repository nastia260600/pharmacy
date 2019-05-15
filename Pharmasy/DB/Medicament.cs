using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Pharmasy.DB
{
    public class Medicament
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public MedicamentType Type { get; set; }
        public string Description { get; set; }
        public string Warning { get; set; }
        public string Href { get; set; }
        public ICollection<Medicament> HasContraindications { get; set; }
        public ICollection<Medicament> ContraindicationTo { get; set; }

    }

    public enum MedicamentType
    {
        Medication,
        DietarySupplement
    }
}
