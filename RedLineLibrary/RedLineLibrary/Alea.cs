using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLineLibrary
{
    public class Alea
    {
        private static Random rnd;

        private Alea()
        {
            rnd = new Random();
        }

        public static Random GetInstance()
        {
            if (rnd == null)
            {
                new Alea();
            }
            return rnd;
        }
    }
}
