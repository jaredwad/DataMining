using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF.DataTypes
{
   public class Rational : Number
   {
      protected override int Priority { get { return 1; } }
      public override int Count       { get { return data.Count; } }

      private List<double> data;

      public Rational()
      {
         data = new List<double>();
      }

      public override double computeMean()
      {
         throw new NotImplementedException();
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
         double temp = 0;

         if( Double.TryParse( item, out temp ) )
            return true; 

         return false;
      }

      public override void add( object item )
      {
         data.Add( (double)item );
      }

      public override void add( string item )
      {
         Console.WriteLine( "Parsing Rational item {0}", item );
         data.Add( Double.Parse( item ) ); //Throws exception if it can't be parsed
         Console.WriteLine( "added Rational item {0}", item );
      }

      public override DataType getNew()
      {
         return new Rational();
      }
   }
}
