using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    internal class Participant : Etat
    {
        public override bool VoterGagnant(Joueur _joueur)
        {
            return false;
        }
        public override Etat? DevenirParticipant()
        {
            return null;
        }
    }
}
