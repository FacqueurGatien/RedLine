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
        private Joueur[] joueurs;
        private Partie partie;

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
        public bool VoterReponse()
        {
            throw new NotImplementedException();
        }
    }
}
