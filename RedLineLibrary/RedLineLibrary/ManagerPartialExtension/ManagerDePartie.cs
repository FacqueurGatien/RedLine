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

        public int IdJoueurCourant { get => idJoueurCourant; }
        public void ChangerJoueur()
        {
            bool found = false;
            while (idJoueurCourant + 1 < joueurs.Count() && !found)
            {
                idJoueurCourant++;
                found = joueurs[idJoueurCourant].Pseudo != juge.Pseudo;
            }
            if (!found)
            {
                // ON PEUT METTRE UN EVENT
            }
        }

        public void EnvoyerReponse()
        {
            //
        }
    }
}
