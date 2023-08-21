using RedLineLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RedLineTesteUnitaire
{
    [TestClass]
    public class TestClassPlateau
    {
        [TestMethod]
        public void Plateau_DonnerCarteQuestionAuMediateur_PaquetPlein()
        {
            Manager manager = new Manager();
            Plateau plateau = new(manager, GenererPaquetQuestion(), null);
            

            CarteQuestion cq = plateau.DonnerCarteQuestionAuMediateur();
            Assert.IsNotNull(cq,"Aucune carte renvoyé");
        }
        [TestMethod]
        public void Plateau_DonnerCarteQuestionAuMediateur_PaquetVide()
        {
            Manager manager = new Manager();
            Plateau plateau = new(manager, new Paquet<CarteQuestion>(new Stack<CarteQuestion>()));
            CarteQuestion cq = plateau.DonnerCarteQuestionAuMediateur();
            Assert.IsNull(cq,"Une carte à été renvoyé");
        }        
        [TestMethod]
        public void Plateau_DonnerCarteReponseAuMediateur_UneCarte_PaquetPlein()
        {
            Manager manager = new Manager();
            Plateau plateau = new(manager, null, GenererPaquetReponse());

            CarteReponse[] cr = plateau.DonnerReponseAuMediateur();
            Assert.IsNotNull(cr,"Aucune carte renvoyé");
        }

        [TestMethod]
        public void Plateau_DonnerCarteReponseAuMediateur_TropDeCartes_PaquetPlein()
        {
            Manager manager = new Manager();
            Plateau plateau = new(manager, null, GenererPaquetReponse());
            Assert.ThrowsException<Exception>(()=>plateau.DonnerReponseAuMediateur(30), "Pas d'exception dans cas de demande trop elevé");
        }

        [TestMethod]
        public void Plateau_DonnerCarteReponseAuMediateur_PaquetVide()
        {
            Manager manager = new Manager();
            Plateau plateau = new(manager, new Paquet<CarteQuestion>(new Stack<CarteQuestion>()));
            Assert.ThrowsException<Exception>(()=> plateau.DonnerReponseAuMediateur(), "Une carte à été renvoyé");
        }
        private Paquet<CarteReponse> GenererPaquetReponse()
        {
            Paquet<CarteReponse> paquetCarteReponse = new Paquet<CarteReponse>(new Stack<CarteReponse>());
            paquetCarteReponse.AjouterCarte(new CarteReponse("Zemmour"));
            paquetCarteReponse.AjouterCarte(new CarteReponse("Les gilets jaunes"));
            paquetCarteReponse.AjouterCarte(new CarteReponse("Les wokes"));
            paquetCarteReponse.AjouterCarte(new CarteReponse("Marlene shiappa"));
            paquetCarteReponse.AjouterCarte(new CarteReponse("Le tournage de brockback mountain"));
            paquetCarteReponse.AjouterCarte(new CarteReponse("Psyhodelick"));
            paquetCarteReponse.AjouterCarte(new CarteReponse("La quadrisomie"));
            return paquetCarteReponse;
        }        
        private Paquet<CarteQuestion> GenererPaquetQuestion()
        {
            Paquet<CarteQuestion> cartesquestions = new Paquet<CarteQuestion>(new Stack<CarteQuestion>());
            cartesquestions.AjouterCarte(new CarteQuestion("Je n'ai jamais compris {0} avant de rencontrer {1}"));
            cartesquestions.AjouterCarte(new CarteQuestion("{0} c'est quand même mieux avec {1}"));
            cartesquestions.AjouterCarte(new CarteQuestion("La nouvelle categorie pornhub : {0}"));
            return cartesquestions;
        }
    }
}
