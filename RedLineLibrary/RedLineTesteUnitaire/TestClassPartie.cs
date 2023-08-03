using RedLineLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineTesteUnitaire
{
    [TestClass]
    public class TestClassPartie
    {
        [TestMethod]
        public void PartieGenererManche_MancheActueldefaut_MancheActuelInstancie()
        {
            Manager manager = new();
            Partie partie = new(manager);

            partie.GenererManche();
            Assert.IsNotNull(partie.RecupererManche(),"Il n'y a pas de manche instancié");
        }
    }
}
