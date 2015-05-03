using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF.DataTypes
{
   public class Nominal : DataType
   {
      protected override int Priority { get { return 0; } }
      public override int Count       { get { return data.Count; } }

      private List<string> data;

      public Nominal()
      {
         data = new List<string>();
      }

      public override void normalize()
      {
      }

      public override double compare( int first, int second )
      {
         return compare( data.ElementAt( first ), data.ElementAt( second ) );
      }

      public override double compare( int first, string second )
      {
         return compare( data.ElementAt( first ), second );
      }

      public override double compare( string first, string second )
      {
         return string.Equals( first, second ) ? 1 : 0;
      }

      public override bool isType( string item )
      {
         return true; // Anything can be nominal
      }

      public override void add( object item )
      {
         data.Add( (string)item );
      }

      public override void add( string item )
      {
         data.Add( item );
      }

      public override DataType getNew()
      {
         return new Nominal();
      }

      public override string getAt( int index )
      {
         return data.ElementAt( index );
      }
   }
}
