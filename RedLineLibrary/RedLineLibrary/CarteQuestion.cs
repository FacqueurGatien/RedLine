using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class CarteQuestion : Carte
    {
        public CarteQuestion(string _text)
            :base(_text)
        {
            if (texte.Count(d => d == '{') == 0)
                throw new Exception("Je suis PILOTE, peut-être, !!!mais ce qui est sur c'est que je ne suis pas une carte question!!!");
        }
        public override string ToString()
        {
            string result = "";
            List<string?> l = new();
            for(int i = 0; i < texte.Count(d=>d == '{'); i++)
            {
                l.Add("___");
            }
            return String.Format(texte, l.ToArray());
        }
    }
}
