using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF.Classification
{
   public class Knn : Classifier
   {
      private int K;

      public Knn(List<DataType> pData, int pK) : base(pData)
      {
         K = pK;
      }

      public override bool train()
      {
         throw new NotImplementedException();
      }

      public override string classify( string[] newRow )
      {
         throw new NotImplementedException();
      }

      private List<int> getNeighbors( int row )
      {
         return null;
      }

      private bool isNeighbor( int first, int second )
      {
         return false;
      }
   }
}
