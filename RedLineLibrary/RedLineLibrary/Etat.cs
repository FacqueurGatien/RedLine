using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{

    public class Etat
    {
        public virtual bool PeutGagnerManche()
        {
            return true;
        }
        public virtual bool VoterGagnant(Joueur _joueur)
        {
            if (_joueur.Etat.PeutGagnerManche())
            {
                _joueur.Elir();
                return true;
            }
            return false;
        }
        public virtual bool SoumettreCarteReponse()
        {
            return true;
        }
        public virtual Etat? DevenirParticipant()
        {
            return new Participant();
        }
        public virtual Etat? Elire()
        {
            return new Juge();
        }
    }
}
