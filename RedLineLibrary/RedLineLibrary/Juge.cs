using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    internal class Juge : Etat
    {
        public override bool PeutGagnerManche()
        {
            return false;
        }
        public override bool SoumettreCarteReponse()
        {
            return false;
        }
        public override Etat? Elire()
        {
            return null;
        }
    }
}
