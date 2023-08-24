using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPartialClass
{
    public partial class Coords
    {
        public string Coucou()
        {
            return String.Format("{0}/{1}", x, y);
        }
    }
}
