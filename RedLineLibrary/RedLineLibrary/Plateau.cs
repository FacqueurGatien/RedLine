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
