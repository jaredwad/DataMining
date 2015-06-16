using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF.DataTypes
{
   class Nominal : DataType
   {
      protected override int Priority
      {
         get { return 1; }
      }

      public override string[] normalize( string[] pData )
      {
         return pData;
      }

      public override double compare( string first, string second )
      {
         throw new NotImplementedException();
      }

      public override bool isType( string item )
      {
         throw new NotImplementedException();
      }

      public override DataType getNew()
      {
         throw new NotImplementedException();
      }
   }
}
