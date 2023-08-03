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

        public Paquet(Stack<T> _cartes, bool _visible = false)
        {
            cartes = _cartes;
            estVisible = _visible;
        }
        public bool EstVisible { get => estVisible; private set => estVisible = value; }

        public void AjouterCarte(T _carte)
        {
            cartes.Push(_carte);
        }
        public void AjouterCarte(T[] _cartes)
        {
            foreach (T carte in _cartes)
            {
                AjouterCarte(carte);
            }
        }
        public T[]? RecupererUnNombreDeCartes(int _qteCartes)
        {
            Paquet<T>? paquet = RecupererUnPaquetdeCarte(_qteCartes);
            return (paquet != null ? paquet.cartes.ToArray() : null);
        }
        public Paquet<T>? RecupererUnPaquetdeCarte(int _qteCartes)
        {
            Stack<T>? rt = RecuperStackDeCartes(_qteCartes);
            return new Paquet<T>(rt??new Stack<T>());
        }

        public Stack<T>? RecuperStackDeCartes(int _qteCartes)
        {
            if (cartes.Count() < _qteCartes)
            {
                return null;
            }
            Stack<T> rt = new Stack<T>();
            for (int i = 0; i < _qteCartes; i++)
            {
                rt.Push(cartes.Pop());
            }
            rt.Reverse();
            return rt;
        }
        public T[] Regarder()
        {
            if (!estVisible)
            {
                return null;
            }
            return cartes.ToArray();
        }
    }
}
