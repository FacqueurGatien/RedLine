using RedLineLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineTesteUnitaire
{
    [TestClass]
    public class TestClassPaquet
    {
        [TestMethod]
        public void PaquetDemarrerPaquet()
        {
            Paquet<CarteReponse> paquet = new Paquet<CarteReponse>(new());
            CarteReponse a = new("a");
            CarteReponse b = new("b");
            CarteReponse[] rep = new CarteReponse[] { a, b };
            paquet.AjouterCarte(rep);
            for (int i = rep.Length-1; i >= 0; i--)
            {
                CarteReponse[] reponse = paquet.RecupererUnNombreDeCartes(1);
                Assert.IsTrue(reponse[0] == rep[i], "Probleme carte recupere mauvaise");
            }
        }
        [TestMethod]
        public void PaquetRegarder_PaquetVisible_RetourOK()
        {
            Paquet<CarteReponse> paquet = new Paquet<CarteReponse>(new(),true);
            CarteReponse a = new("a");
            CarteReponse b = new("b");
            CarteReponse[] rep = new CarteReponse[] { a, b };
            paquet.AjouterCarte(rep);

            Assert.IsTrue(paquet.Regarder() != null,"Le paquet n'as aucune carte (retour null)");
        }
        [TestMethod]
        public void PaquetRegarder_PaquetNonVisible_RetourNull()
        {
            Paquet<CarteReponse> paquet = new Paquet<CarteReponse>(new());
            CarteReponse a = new("a");
            CarteReponse b = new("b");
            CarteReponse[] rep = new CarteReponse[] { a, b };
            paquet.AjouterCarte(rep);

            Assert.IsTrue(paquet.Regarder() == null, "Le paquet contient des cartes (retour attendu null)");
        }
        [TestMethod]
        public void PaquetRecupererNombreDeCartes_ArgumentsCartes2_Retour2Cartes()
        {
            Paquet<CarteReponse> paquet = new Paquet<CarteReponse>(new());
            CarteReponse a = new("a");
            CarteReponse b = new("b");
            CarteReponse[] rep = new CarteReponse[] { a, b };
            paquet.AjouterCarte(rep);
            CarteReponse[] reponses = paquet.RecupererUnNombreDeCartes(2);
            for (int i = 0; i < reponses.Length; i++)
            {
                Assert.IsTrue(reponses[i] == rep[i],"La carte n'est pas celle attendu");
            }
        }
    }
}
