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

        public int Count => cartes.Count();

        public Paquet(Stack<T> _cartes, bool _visible = false)
        {
            cartes = _cartes??new Stack<T>();
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
            return rt == null ? null : new Paquet<T>(rt);
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

        public void Melanger()
        {
            List<T> reponses = cartes.ToList();
            Stack<T> resultat = new();
            while (reponses.Count > 0)
            {
                int idAAjoute = Alea.GetInstance().Next(0, reponses.Count());
                resultat.Push(reponses[idAAjoute]);
                reponses.RemoveAt(idAAjoute);
            }
            cartes = resultat;
        }
    }
}
