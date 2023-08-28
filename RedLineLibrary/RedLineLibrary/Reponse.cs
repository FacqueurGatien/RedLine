using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class Reponse
    {
        private Joueur joueur;
        private Paquet<CarteReponse> paquetReponse;
        public Reponse(Joueur _joueur, Paquet<CarteReponse> _paquetReponse)
        {
            joueur = _joueur;
            paquetReponse = _paquetReponse;
        }

        public Joueur Joueur { get => joueur;}

        public Paquet<CarteReponse>? ObtenirReponse(Joueur j)
        {
            if (j.Role == EnumRole.Participant && !paquetReponse.EstVisible)
                return null;
            return paquetReponse;
        }

        public void RedonnerCartes()
        {
            CarteReponse[] rep = paquetReponse.RecupererUnNombreDeCartes(paquetReponse.Count);
            for (int i = 0; i < rep.Length; i++)
            {
                joueur.RecevoirCarteReponse(rep[i]);
            }
        }
    }
}
