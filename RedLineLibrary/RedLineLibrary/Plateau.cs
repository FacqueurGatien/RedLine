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
        public Plateau(Manager _manager, Paquet<CarteQuestion> _paquetCarteQuestion=null, Paquet<CarteReponse> _paquetCarteReponse=null)
        {
            manager = _manager;
            paquetCarteQuestion = _paquetCarteQuestion??new Paquet<CarteQuestion>(new Stack<CarteQuestion>());
            paquetCarteReponse = _paquetCarteReponse??new Paquet<CarteReponse>(new Stack<CarteReponse>());
            manager.Initialize(this);

        }
        public CarteQuestion? DonnerCarteQuestionAuMediateur()
        {
            CarteQuestion[]? retour = paquetCarteQuestion.RecupererUnNombreDeCartes(1);
            return retour == null ? null : retour[0];
        }
        public CarteReponse[]? DonnerReponseAuMediateur(int _qteCarte=1)
        {
            CarteReponse[] rt = paquetCarteReponse.RecupererUnNombreDeCartes(_qteCarte);
            if (rt != null && rt.Length == _qteCarte)
                return rt;
            throw new Exception("Le nombre de cartes demandé n'est pas disponible");
        }
    }
}
