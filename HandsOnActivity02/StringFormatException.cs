using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnActivity02
{
    class StringFormatException: Exception
    {
        public StringFormatException(string str) : base(str)
        {

        }
    }
}
