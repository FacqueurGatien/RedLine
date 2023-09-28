using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class Joueur
    {     
        private Manager manager;
        private EnumRole role;
        private string pseudo;
        private List<CarteReponse> saMain;
        private int score;
        public string Pseudo { get => pseudo; private set => pseudo = value; }
        public EnumRole Role { get => role; }
        private List<int> idCartesSelectionnes;

        public List<CarteReponse> Main { get => saMain; }

        /* TO DO :
         * Mettre les carte dans une collection a part pour pouvoir
         * les separer de la main quand elles sont selectionnées
         */

        public int Score { get => score; }

        public Joueur(Manager manager, string pseudo) : this(manager, EnumRole.Participant, pseudo) { }
        public Joueur(Manager _manager, EnumRole _role, string _pseudo)
        {
            idCartesSelectionnes = new List<int>();
            saMain = new List<CarteReponse>();
            manager = _manager;
            role = _role;
            pseudo = _pseudo;
            score = 0;
            manager.Initialize(this);

        }

        public bool SelectionnerCarte(int id)
        {
            if (id >= saMain.Count())
                return false;
            else if (idCartesSelectionnes.FindAll(d => d == id).Count() > 0)
                return false;
            idCartesSelectionnes.Add(id);
            return true;
        }

        public bool DonnerReponseAuMediateur()
        {
            Reponse rp = ComposerReponse(idCartesSelectionnes.ToArray());
            
            if (manager.EnvoyerReponse(this, rp))
            {
                
                idCartesSelectionnes.Clear();
                return true;
            }
            return false;
        }

        // Id des cartes en ordre LIFO
        public Reponse ComposerReponse(int[] _cartesId)
        {
            // TRI CROISSANT
            List<int> cartesId = new List<int>(_cartesId);
            cartesId.Sort((a, b) => a - b);
            // VERIFICATION AUCUN DOUBLON
            bool doublon = false;
            int i = 1;
            while (i < cartesId.Count && !doublon)
            {
                doublon = cartesId[i] == cartesId[i - 1];
                i++;
            }
            // EXCEPTIONS DOUBLONS ET INTERVALLE DES IDS
            if (doublon)
                throw new Exception("Erreur doublon");
            if (cartesId[cartesId.Count - 1] >= saMain.Count)
                throw new Exception("id trop grand");
            if (cartesId[0] < 0)
                throw new Exception("id trop petit");
            // GENERATION DU PAQUET ET RETRAIT DES CARTES DE LA MAIN
            Paquet<CarteReponse> paquet = new Paquet<CarteReponse>(new());
            foreach (int id in _cartesId)
            {
                paquet.AjouterCarte(saMain[id]);
                saMain.RemoveAt(id);
            }
            Reponse reponse = new Reponse(this, paquet);
            return reponse;
        }
        /*public bool DemanderCartesReponse(int _qteCarte)
        {
            manager.RedistribuerCarteReponseAuJoueursNonJuge
        }*/
        public bool RecevoirCartesReponse(CarteReponse[] _cartes)
        {
            saMain.AddRange(_cartes);
            return true;
        }

        public bool RecevoirCarteReponse(CarteReponse _carte) { 
            saMain.Add(_carte);
            return true;
        }
        public void RegarderReponse(int _idReponse)
        {
            manager.DemanderVoirReponse(this,_idReponse);
        }
        public void VoterReponse(int _idReponse)
        {
            manager.VoterReponse(this,_idReponse);
        }
        public void ChangerRole()
        {
            role = (role == EnumRole.Juge ? EnumRole.Participant : EnumRole.Juge);
        }

        public void AugmenterScore()
        {
            if (this.Role == EnumRole.Participant)
                score++;
        }
    }
}
