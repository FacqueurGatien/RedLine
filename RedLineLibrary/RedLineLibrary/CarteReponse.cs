using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class CarteReponse : Carte
    {
        public CarteReponse(string _text)
            :base(_text) 
        {
        }
        public override string ToString()
        {
            return texte;
        }
    }
}
