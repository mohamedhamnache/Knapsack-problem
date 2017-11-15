using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPGO_SacADos.Classes
{
    class Case
    {
        private int value;
        public HashSet<int> objet = new HashSet<int>();

        public void setValue(int value)
        {
            this.value = value;
        }

        public int getValue()
        {
            return this.value;
        }

        public void addObject(int objet)
        {
            this.objet.Add(objet);
        }

        public void setListObject(HashSet<int> listObject)
        {
            this.objet = listObject;
        }
        public HashSet<int> getListObject()
        {
            return this.objet;
        }

    }
}
