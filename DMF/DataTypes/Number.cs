using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF
{
   public abstract class Number : DataType
   {
      double standardDiviation;
      double mean;
      public abstract double computeMean();
   }
}
