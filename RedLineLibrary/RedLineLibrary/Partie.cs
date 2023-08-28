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
        private readonly int scoreAAvoir;
        private readonly int carteParJoueurs;

        public int ScoreAAvoir { get => scoreAAvoir;  }
        public int CarteParJoueurs { get => carteParJoueurs;  }
        public Partie(Manager _manager, int _score = 5, int _carteParJoueurs = 7)
        {
            manager = _manager;
            manager.Initialize(this);
            scoreAAvoir = _score;
            carteParJoueurs = _carteParJoueurs;
        }
        public void GenererManche()
        {
            mancheActuelle = new Manche(manager.DemanderCarteQuestionAuPlateau());
        }
        public Manche RecupererManche() => mancheActuelle;
    }
}
