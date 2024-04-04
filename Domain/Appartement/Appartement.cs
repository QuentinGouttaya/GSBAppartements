using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBAppartement.Domain.Appartement
{
    public class Appartement
    {
        public Guid id { get; set; }
        public string type_appart { get; set; }
        public decimal prix_loc { get; set; }
        public decimal prix_charge { get; set; }
        public string adresse { get; set; }
        public string ville { get; set; }
        public string code_postal { get; set; }
        public string etage { get; set; }
        public bool avec_ascenseur { get; set; }
        public bool avec_preavis { get; set; }
        public DateTime date_libre { get; set; }
        public Guid id_proprietaire { get; set; }
        public int id_arrondissement { get; set; }
    }


}
