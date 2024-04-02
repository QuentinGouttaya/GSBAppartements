using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBAppartement.Domain.Personnes
{
    public class Locataire : Personne 
    {
        public int rib { get; set; }

        public int idAppartement { get; set; }
    }
}
