using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF
{
   public abstract class DataType : IComparable<DataType>
   {
      protected abstract int Priority { get; }

      public IEnumerable<string> normalize( IEnumerable<string> pData ) { return new List<string>( normalize( pData.ToArray() ) ); }
      public abstract string[]   normalize( string[] pData );
      public abstract double compare( string first, string second );
      public abstract bool isType( string item );

      public abstract DataType getNew();

      public int CompareTo( DataType other )
      {
         int oP = other.Priority;

         if( oP == Priority ) { return 0; } // Same Priority
         if( oP >  Priority ) { return 1; } // Other comes First

         return -1; // This comes first
      }
   }
}
