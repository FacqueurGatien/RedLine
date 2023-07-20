using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class Manche
    {
        private CarteQuestion question;
        private List<Reponse> reponses;

        public Reponse[] Reponses { get => reponses.ToArray(); }
        public Manche(CarteQuestion _question) 
        {
            question= _question;
            reponses = new();
        }
        public Paquet<CarteReponse>? RetournerReponse(Joueur j, int n)
        {
            if (j.Role == EnumRole.Participant || n >= reponses.Count)
                return null;
            return reponses[n].ObtenirReponse(j);
        
        }

        public Joueur? RetournerJoueurReponse(Joueur j, int n)
        {
            if (j.Role == EnumRole.Participant || n >= reponses.Count)
                return null;
            return reponses[n].Joueur;

        }
        public bool SoumettreReponse(Reponse reponse)
        {
            if (reponse.Joueur.Role == EnumRole.Juge)
                return false;
            reponses.Add(reponse);
            return true;
        }

        public bool SoumettreReponse(Joueur j, Paquet<CarteReponse> cartes) => SoumettreReponse(new Reponse(j, cartes));
        public CarteQuestion VoirQuestion() => question;
    }
}
