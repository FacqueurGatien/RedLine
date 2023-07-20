using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public abstract class Carte
    {
        protected string texte;
        public Carte(string _texte)
        {
            texte = _texte;
        }
        public abstract string ToString();
    }
}
