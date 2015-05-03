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

      public override bool train() { return true; }

      public override string classify( string[] newRow )
      {
         for(int i = 0; i < newRow.Length; ++i) {
            data.ElementAt(i).add(newRow[i]);
         }

         return classify( data.ElementAt( 0 ).Count - 1 );
      }

      public override string classify( int index )
      {
         List<string> neighbors = getNeighbors( index );

         string top = neighbors
            .GroupBy( i => i )
            .OrderByDescending( g => g.Count() )
            .Take( 1 )
            .Select( g => g.Key ).ElementAt( 0 );

         return top;
      }

      private List<string> getNeighbors( int row )
      {
         List<Tuple<int, double>> values = new List<Tuple<int, double>>();


         for( int i = 0; i < data.ElementAt( 0 ).Count; ++i ) {
            if( i == row ) { continue; }

            double distance = 0;
            for( int j = 0; j < data.Count; ++j ) {
               distance += data.ElementAt( j ).compare( i, row );
            }

            values.Add( new Tuple<int, double>( i, distance ) );
         }

         values = values.OrderBy( x => x.Item2 ).ToList();

         List<string> categories = new List<string>();

         for( int i = 0; i < K; ++i ) {
            int index = values.ElementAt( i ).Item1;

            string category = data.ElementAt( data.Count - 1 ).getAt( index );

            categories.Add( category );
         }

            return categories;
      }

      private bool isNeighbor( int first, int second )
      {
         return false;
      }


   }
}
