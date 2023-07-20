using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class Partie
    {
        private Manche mancheActuelle;
        private Manager manager;
        public Partie(Manager _manager)
        {
            manager = _manager;
        }
        public void GenererManche()
        {
            mancheActuelle = new Manche(manager.DemanderCarteQuestionAuPlateau());
        }
        public Manche RecupererManche() => mancheActuelle;
    }
}
