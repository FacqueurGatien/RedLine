using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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


        public Manager()
        {
            plateau = default;
            joueurs = new List<Joueur>();
            partie = default;
            juge = default;
        }
        public void Initialize(Plateau _plateau)
        {
            plateau= _plateau;
        }
        public void Initialize(Partie _partie)
        {
            _partie = _partie;
        }
        public void Initialize(Joueur _joueurs)
        {
            joueurs.Add(_joueurs);
        }
        public bool RedistribuerCarteReponseAuJoueursNonJuge()
        {
            int nbCartesADistribuer = partie.RecupererManche().VoirQuestion().NombreDeTrous();

            CarteReponse[]? cartes = plateau.DonnerReponseAuMediateur((joueurs.Count() - 1) * nbCartesADistribuer);
            if (cartes == null)
                return false;
            Stack<CarteReponse> cartesToStack = new Stack<CarteReponse>(cartes);
                for (int i = 0; i < nbCartesADistribuer; i++)
                {
                    foreach (Joueur j in joueurs.FindAll(d => d.Role == EnumRole.Participant).ToArray())
                    {
                        j.RecevoirCarteReponse(cartes[i]);
                    }
                }
            return true;
        }
        public CarteQuestion DemanderCarteQuestionAuPlateau()
        {
            return plateau.DonnerCarteQuestionAuMediateur();
        }
        public Paquet<CarteReponse>? DemanderVoirReponse(Joueur _juge,int _idReponse)
        {
            if (_juge.Role != EnumRole.Juge)
                return null;
            return partie.RecupererManche().RetournerReponse(_juge, _idReponse);
        }
        public bool VoterReponse(Joueur juge,int n)
        {
            if (juge.Role != EnumRole.Juge)
                return false;
            Manche manche = partie.RecupererManche();
            Joueur participant = manche.RetournerJoueurReponse(juge, n);
            if (participant == null)
                return false;
            RedistribuerCarteReponseAuJoueursNonJuge();
            participant.AugmenterScore();
            participant.ChangerRole();
            juge.ChangerRole();
            juge = participant;
            return true;
        }
    }
}
