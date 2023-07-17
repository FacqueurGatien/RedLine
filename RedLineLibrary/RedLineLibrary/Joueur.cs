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
        public Paquet<CarteReponse> RegarderReponse(int _idReponse)
        {
            throw new NotImplementedException();
        }
        public void VoterReponse(int _idReponse)
        {
            throw new NotImplementedException();
        }
    }
}
