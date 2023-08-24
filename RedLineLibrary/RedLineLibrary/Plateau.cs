using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class Plateau
    {
        private Paquet<CarteReponse> paquetCarteReponse;
        private Paquet<CarteQuestion> paquetCarteQuestion;
        private Paquet<CarteReponse> defausseReponse;
        private Manager manager;

        public delegate void NotifierDerniereCarteTiree(object sender, EnumPlateauTypePaquet type);
        public event NotifierDerniereCarteTiree eventDerniereCarteTireePiocheReponse;
        public event NotifierDerniereCarteTiree eventDerniereCarteTireePiocheQuestion;

        public Plateau(Manager _manager, Paquet<CarteQuestion> _paquetCarteQuestion=null, Paquet<CarteReponse> _paquetCarteReponse=null, Paquet<CarteReponse> _paquetDefausseReponse=null)
        {
            manager = _manager;
            paquetCarteQuestion = _paquetCarteQuestion??new Paquet<CarteQuestion>(new Stack<CarteQuestion>());
            paquetCarteReponse = _paquetCarteReponse??new Paquet<CarteReponse>(new Stack<CarteReponse>());
            defausseReponse = _paquetDefausseReponse ?? new Paquet<CarteReponse>(new Stack<CarteReponse>());
            manager.Initialize(this);
            eventDerniereCarteTireePiocheReponse += (sender, type) => this.PlacerDefausseDansLaPiocheEtMelanger();
            paquetCarteQuestion.Melanger();
            paquetCarteReponse.Melanger();
        }
        public CarteQuestion? DonnerCarteQuestionAuMediateur()
        {
            CarteQuestion[]? retour = paquetCarteQuestion.RecupererUnNombreDeCartes(1);
            if (retour != null 
                && paquetCarteQuestion.Count == 0 
                && eventDerniereCarteTireePiocheQuestion != null)
            {
                eventDerniereCarteTireePiocheQuestion(paquetCarteQuestion, EnumPlateauTypePaquet.PIOCHE_QUESTION);
            }
            return retour == null ? null : retour[0];
        }
        public CarteReponse[]? DonnerReponseAuMediateur(int _qteCarte=1)
        {
            if (paquetCarteReponse.Count + defausseReponse.Count < _qteCarte)
                throw new Exception("Le nombre de cartes demandé n'est pas compatible avec le plateau (le chien à mangé les cartes?)");
            List<CarteReponse> rt = paquetCarteReponse.RecupererUnNombreDeCartes(Math.Min(_qteCarte, paquetCarteReponse.Count)).ToList();
            if (rt == null)
                throw new Exception("Le nombre de cartes demandé n'est pas disponible");
            if (rt.Count() == _qteCarte)
            {
                if (paquetCarteReponse.Count == 0
                && eventDerniereCarteTireePiocheReponse != null)
                {
                    eventDerniereCarteTireePiocheReponse(paquetCarteReponse, EnumPlateauTypePaquet.PIOCHE_REPONSE);
                }                    
            } 
            else
            {
                int carteRestantes = _qteCarte - rt.Count();
                if (paquetCarteReponse.Count == 0
                && eventDerniereCarteTireePiocheReponse != null)
                {
                    eventDerniereCarteTireePiocheReponse(paquetCarteReponse, EnumPlateauTypePaquet.PIOCHE_REPONSE);
                }
                rt.AddRange(paquetCarteReponse.RecupererUnNombreDeCartes(carteRestantes));
            }
            return rt.ToArray();   
        }



        public void PlacerDansLaDefausseDeReponse(CarteReponse carteReponse)
        {
            defausseReponse.AjouterCarte(carteReponse);
        }

        private void PlacerDefausseDansLaPiocheEtMelanger()
        {
            paquetCarteReponse.AjouterCarte(defausseReponse.RecupererUnNombreDeCartes(defausseReponse.Count));
            paquetCarteReponse.Melanger();            
        }

       
    }
}
