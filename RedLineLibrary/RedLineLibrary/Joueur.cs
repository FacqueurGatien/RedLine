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
        private int score;
        public string Pseudo { get => pseudo; private set => pseudo = value; }
        public EnumRole Role { get => role; }

        public Joueur(Manager _manager, EnumRole _role, string _pseudo)
        {
            manager = _manager;
            role = _role;
            pseudo = _pseudo;
            score = 0;
        }
        public Reponse ComposerReponse(int[] _cartesId)
        {
            throw new NotImplementedException();
        }
        public bool DemanderCartesReponse(int _qteCarte)
        {
            throw new NotImplementedException();
        }
        public bool RecevoirCartesReponse(CarteReponse[] _cartes)
        {
            throw new NotImplementedException();
        }

        public bool RecevoirCarteReponse(CarteReponse _carte)
        {
            return RecevoirCartesReponse(new CarteReponse[]{ _carte});
        }
        public Paquet<CarteReponse> RegarderReponse(int _idReponse)
        {
            throw new NotImplementedException();
        }
        public void VoterReponse(int _idReponse)
        {
            throw new NotImplementedException();
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
