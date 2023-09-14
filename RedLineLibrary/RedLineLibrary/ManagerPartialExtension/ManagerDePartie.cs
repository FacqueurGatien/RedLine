using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public partial class Manager
    {
        private int idJoueurCourant;

        public int IdJoueurCourant { get => idJoueurCourant;
            private set => ChangerJoueurCourant(value); 
        }

        private void ChangerJoueurCourant(int id)
        {
            if (id != null && idJoueurCourant != id)
            {
                idJoueurCourant = id;
                if (Event_OnPlayerChange != null)
                    Event_OnPlayerChange(joueurs[idJoueurCourant]);
            }

        }


        public void ChangerJoueur()
        {
            /*bool found = false;
            while (idJoueurCourant + 1 < joueurs.Count() && !found)
            {
                idJoueurCourant++;
                found = joueurs[idJoueurCourant].Pseudo != juge.Pseudo;
            }
            if (!found)
            {

            }
            */
            if (AUnParticipant(out int id))
            {
                IdJoueurCourant = id;
                
            } else
            {
                IdJoueurCourant = joueurs.Count() - 1;
            }
        }

        public bool AUnParticipant(out int idTemp)
        {
            idTemp = idJoueurCourant;
            bool found = false;
            while (idTemp + 1 < joueurs.Count() && !found)
            {
                idTemp++;
                found = joueurs[idTemp].Pseudo != juge.Pseudo;
            }
            return found;
        }

        public bool AUnParticipant()
        {
            int idTemp = idJoueurCourant;
            bool found = false;
            while (idTemp + 1 < joueurs.Count() && !found)
            {
                idTemp++;
                found = joueurs[idTemp].Pseudo != juge.Pseudo;
            }
            return found;
        }

        public bool EnvoyerReponse(Joueur participant, Reponse rep)
        {
            //
            if (!AUnParticipant())
                return false;
            Manche m = partie.RecupererManche();
            if (participant.Role != EnumRole.Participant ||
                !m.SoumettreReponse(rep))
            {
                // ON REDONNE LES CARTES AU PARTICIPANT ON RENVOIE FALSE
                rep.RedonnerCartes();
                return false;
            }
            return true;

        }
    }
}
