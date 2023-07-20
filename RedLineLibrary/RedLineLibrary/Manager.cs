using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class Manager
    {
        private Plateau plateau;
        private List<Joueur> joueurs;
        private Partie partie;
        private Joueur juge; 

        public Manager(Plateau _plateau, List<Joueur> _joueur,Partie _partie)
        {
            plateau = _plateau;
            joueurs = _joueur;
            partie = _partie;
            juge = joueurs[new Random().Next(0, joueurs.Count)];
        }

        public bool DemandeCarteReponseAuPlateauPourLeJoueur(string _pseudo, int _qteCarte)
        {
            throw new NotImplementedException();
        }
        public CarteQuestion DemanderCarteQuestionAuPlateau()
        {
            throw new NotImplementedException();
        }
        public Paquet<CarteReponse> DemanderVoirReponse(int _idReponse,string _pseudoJoueur)
        {
            throw new NotImplementedException();
        }
        public bool VoterReponse(Joueur juge,int n)
        {
            if (juge.Role != EnumRole.Juge)
                return false;
            Manche manche = partie.RecupererManche();
            Joueur participant = manche.RetournerJoueurReponse(juge, n);
            if (participant == null)
                return false;
            participant.AugmenterScore();
            participant.ChangerRole();
            juge.ChangerRole();
            juge = participant;
            return true;
        }
    }
}
