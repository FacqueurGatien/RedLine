﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class ObjectCollection
    {
        public List<Card> questions {  get; set; }
        public List<Card> reponses {  get; set; }
    }
}
