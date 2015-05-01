using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF
{
   public abstract class DataType : IComparable<DataType>
   {
      public    abstract int Count { get; }
      protected abstract int Priority { get; }

      public abstract void normalize();
      public abstract double compare( int first, int second );
      public abstract bool isType( string item );
      public abstract void add( object item );
      public abstract void add( string item );

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
