using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnActivity02
{
    class NumberFormatException : Exception
    {
        public NumberFormatException(string numb) : base(numb) {
        
        }
    }
}
