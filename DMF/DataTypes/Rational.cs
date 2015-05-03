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
         double total = 0;
         foreach( var item in data ) {
            total += item;
         }

         return total / data.Count;
      }

      public override void normalize()
      {
         double mean = computeMean();

         double standardDiviation = computeStandardDiviation( mean );

         for(int i = 0; i < data.Count; ++i) {
            data[i] = ( data[i] - mean ) / standardDiviation;
         }
      }

      public double compare( double first, double second )
      {
         return Math.Pow( ( first - second ), 2 );
      }

      public override double compare( int first, int second )
      {
         return compare( data.ElementAt( first ), data.ElementAt( second ) );
      }

      public override double compare( int first, string second )
      {
         return compare( data.ElementAt( first ), Double.Parse( second ) );
      }

      public override double compare( string first, string second )
      {
         return compare( Double.Parse( first ), Double.Parse( second ) );
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
         data.Add( Double.Parse( item ) ); //Throws exception if it can't be parsed
      }

      public override DataType getNew()
      {
         return new Rational();
      }

      public override string getAt( int index )
      {
         return data.ElementAt( index ).ToString();
      }

      private double computeStandardDiviation( double mean )
      {
         double total = 0;

         foreach( var item in data ) {
            total = Math.Pow( ( item - mean ), 2 );
         }

         return total / data.Count;
      }
   }
}
