using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF.Classification
{
   public class HardCoded : Classifier
   {
      public HardCoded( List<DataType> pData ) : base( pData ) { }

      public override bool train()
      {
         return true;
      }

      public override string classify( string[] newRow )
      {
         return categories.ElementAt(0);
      }
   }
}
