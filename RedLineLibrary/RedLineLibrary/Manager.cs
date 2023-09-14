using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public partial class Manager
    {
        private Plateau plateau;
        private List<Joueur> joueurs;
        private Partie partie;
        private Joueur juge;
        private bool demarree;
        public delegate void OnWinEvent(Joueur j);
        public delegate void OnPlayerChange(Joueur j);
        public event OnWinEvent Event_OnWin;
        public event OnPlayerChange Event_OnPlayerChange;
        public Joueur Juge { get => juge; }
        public Manager()
        {
            plateau = default;
            joueurs = new List<Joueur>();
            partie = default;
            juge = default;
            demarree = false;
            idJoueurCourant = -1;

        }
        public void Initialize(Plateau _plateau)
        {
            if (demarree)
                throw new Exception("Deja demarrer");
            plateau = _plateau;

        }
        public void Initialize(Partie _partie)
        {
            if (demarree)
                throw new Exception("Deja demarrer");
            partie = _partie;
        }
        public void Initialize(Joueur _joueurs)
        {
            if (demarree)
                throw new Exception("Deja demarrer");
            joueurs.Add(_joueurs);
        }

        public bool Demarrer()
        {
            // ON VA VERIFIER AVANT DE DEMARRER
            if (plateau == null ||
                partie == null ||
                partie.RecupererManche() != null ||
                joueurs == null ||
                joueurs.Count() < 3)
            {
                return false;
            }
            // ON DECIDE D'UN JUGE ALEATOIREMENT
            juge = joueurs[Alea.GetInstance().Next(0, joueurs.Count())];
            partie.GenererManche();
            DistribuerCarteReponseAuxJoueurs();
            demarree = true;
            ChangerJoueur();
            return true;
        }

        public bool DistribuerCarteReponseAuxJoueurs()
        {
            bool error = false;
            int i, j;
            i = 0;

            int[] datas = joueurs.Select(d => partie.CarteParJoueurs - d.Main.Count).ToArray();
            int sum = datas.Sum();
            CarteReponse[] cartes = plateau.DonnerCarteReponseAuMediateur(sum);
            if (cartes == null)
                return false;
            int idCarte = 0;
            while (i < partie.CarteParJoueurs)
            {
                j = 0;
                while (j < joueurs.Count())
                {
                    error = joueurs[j].Main.Count() >= partie.CarteParJoueurs;
                    if (!error)
                    {
                        joueurs[j].RecevoirCarteReponse(cartes[idCarte]);
                        idCarte++;
                    }
                    j++;
                }
                i++;
            }

            return error;
        }
        public CarteQuestion DemanderCarteQuestionAuPlateau()
        {
            return plateau.DonnerCarteQuestionAuMediateur();
        }
        public Paquet<CarteReponse>? DemanderVoirReponse(Joueur _juge, int _idReponse)
        {
            if (_juge.Role != EnumRole.Juge)
                return null;
            return partie.RecupererManche().RetournerReponse(_juge, _idReponse);
        }
        public bool VoterReponse(Joueur juge, int n)
        {
            if (AUnParticipant())
                return false;
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
            if (participant.Score == partie.ScoreAAvoir)
            {
                // GAGNANT
                if (Event_OnWin != null)
                    Event_OnWin(participant);
            }
            else
            {
                DistribuerCarteReponseAuxJoueurs();
                GenererManche();
            }
            return true;
        }

        public bool GenererManche()
        {

            if (joueurs.FirstOrDefault(j => j.Score >= partie.ScoreAAvoir) != null)
            {
                // IL Y'A EN THEORIE UN GAGNANT
                return false;
            }
            partie.GenererManche();
            idJoueurCourant = -1;
            return true;
        }

        public void MettreDansLaDefausseDeReponse(CarteReponse _carteReponse)
        {
            plateau.PlacerDansLaDefausseDeReponse(_carteReponse);
        }
    }
}
