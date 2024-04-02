﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBAppartement.Domain.Personnes
{
    public abstract class Personne
    {
        public string prenom { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }
        public string ville { get; set; }
        public int codePostal { get; set; }
        public int numeroTel { get; set; }
    }
}
