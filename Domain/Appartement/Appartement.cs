using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBAppartement.Domain.Appartement
{
    public class Appartement
    {
    public Guid Id { get; set; }
    public string TypeAppart { get; set; }
    public decimal PrixLoc { get; set; }
    public decimal PrixCharge { get; set; }
    public string Adresse { get; set; }
    public string Ville { get; set; }
    public string CodePostal { get; set; }
    public string Etage { get; set; }
    public bool AvecAscenseur { get; set; }
    public bool AvecPreavis { get; set; }
    public DateTime DateLibre { get; set; }
    public Guid IdProprietaire { get; set; }
    public int IdArrondissement { get; set; }
    }

    
}
