using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class Plateau
    {
        private Paquet<CarteReponse> paquetCarteReponse;
        private Paquet<CarteQuestion> paquetCarteQuestion;
        private Manager manager;
        public Plateau(Manager _manager, Paquet<CarteQuestion> _paquetCarteQuestion, Paquet<CarteReponse> _paquetCarteReponse)
        {
            manager = _manager;
            paquetCarteQuestion = _paquetCarteQuestion;
            paquetCarteReponse = _paquetCarteReponse;
        }
        public CarteQuestion DonnerCarteQuestionAuMediateur()
        {
            throw new NotImplementedException();
        }
        public CarteReponse[] DonnerReponseAuMediateur(int qteCarte)
        {
            throw new NotImplementedException();
        }
    }
}
