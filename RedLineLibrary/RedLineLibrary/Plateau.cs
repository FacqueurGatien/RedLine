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
            manager.Initialize(this);
        }
        public CarteQuestion? DonnerCarteQuestionAuMediateur()
        {
            CarteQuestion[]? retour = paquetCarteQuestion.RecupererUnNombreDeCartes(1);
            return retour == null ? null : retour[0];
        }
        public CarteReponse[]? DonnerReponseAuMediateur(int _qteCarte)
        {
            return paquetCarteReponse.RecupererUnNombreDeCartes(_qteCarte);
        }
    }
}
