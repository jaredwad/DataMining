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
         throw new NotImplementedException();
      }

      public override double compare( int first, int second )
      {
         throw new NotImplementedException();
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
         Console.WriteLine( "added Nominal item {0}", item );
      }

      public override DataType getNew()
      {
         return new Nominal();
      }
   }
}
