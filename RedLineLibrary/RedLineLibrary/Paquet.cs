using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class Paquet<T> where T : Carte
    {
        private bool estVisible;
        private Stack<T> cartes;

        public Paquet(Stack<T> _cartes)
        {
            cartes = _cartes;
           
        }

        public bool EstVisible { get => estVisible; private set => estVisible = value; }

        public bool AjouterCarte(T _carte)
        {
            throw new NotImplementedException();
        }
        public bool AjouterCarte(T[] _cartes)
        {
            throw new NotImplementedException();
        }
        public T[] RecupererUnNombreDeCartes(int _qteCartes)
        {
            throw new NotImplementedException();
        }
        public T[] Regarder()
        {
            throw new NotImplementedException();
        }
    }
}
