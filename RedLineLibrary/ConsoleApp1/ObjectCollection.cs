using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class ObjectCollection
    {
        public List<object> questions {  get; set; }
        public List<object> reponses {  get; set; }
    }
}
