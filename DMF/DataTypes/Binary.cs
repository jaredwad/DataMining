using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF.DataTypes
{
   public class Binary : DataType
   {
      protected override int Priority { get { return 0; } }
//      public override int Count       { get { return data.Count; } }

//      private List<string> data;

      public Binary()
      {
//         data = new List<string>();
      }

      public IEnumerable<string> normalize(IEnumerable<string> pData)
      {
         return pData;
      }

      public override double compare( string first, string second )
      {
         return string.Equals( first, second ) ? 1 : 0;
      }

      public override bool isType( string item )
      {
         return true; // Anything can be nominal
      }

      public override DataType getNew()
      {
         return new Binary();
      }
   }
}
