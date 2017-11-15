using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPGO_SacADos.Classes
{
    class ObjetSac
    {
        public string nom { get; set; }
        public int weight { get; set; }
        public int value { get; set; }

        public ObjetSac(string nom,int weight,int value)
        {
            this.nom = nom;
            this.weight = weight;
            this.value = value;
        }

        public string getNom()
        {
            return this.nom;
        }
        public int getWeight ()
        {
            return this.weight;
        }
        public int getValue()
        {
            return this.value;
        }
    }
}
