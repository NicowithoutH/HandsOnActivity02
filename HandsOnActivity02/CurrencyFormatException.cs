using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnActivity02
{
    class CurrencyFormatException: Exception
    {
        public CurrencyFormatException(string doub) : base(doub)
        {

        }
    }
}
