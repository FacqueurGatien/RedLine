using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class Joueur
    {
        private string pseudo;
        private int score;
        private Etat etat;

        public Etat Etat { get => etat; }

        public bool Elir()
        {
            Etat futurEtat = etat.Elire();
            if (futurEtat != null)
            {
                etat = futurEtat;
                return true;
            }
            return false;
        }
        public bool DevenirParticipant()
        {
            Etat futurEtat = etat.DevenirParticipant();
            if (futurEtat != null)
            {
                etat = futurEtat;
                return true;
            }
            return false;
        }
        public bool VoterGagnant(Joueur _joueur)
        {
            return etat.VoterGagnant(_joueur);
        }
    }
}
