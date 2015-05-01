using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF
{
   public class DataSet
   {
      private List<DataType> trainingData;
      private List<DataType> testData;
      private List<string>   headers;

      public List<DataType> TrainingData { get { return trainingData; } }
      public List<DataType> TestData     { get { return testData;     } }
      public List<string>   Headers      { get { return headers;      } }

      public DataSet( List<string[]> pData )
         : this( .7, .3, pData ) { }

      public DataSet( double trainingPercent, double testPercent, List<string[]> pData )
      {
         splitData( trainingPercent, testPercent, pData );
      }

      private void splitData( double trainingPercent, double testPercent, List<string[]> pData )
      {
         if( trainingPercent + testPercent != 1.0 ) {
            throw new ArgumentException( string.Format( "Cannont split data into groups that dont add up to 1.0 ( 100% ) {0} + {1} = {3}",
               trainingPercent, testPercent, trainingPercent + testPercent ) );
         }

         headers = new List<string>( pData.ElementAt( 0 ) ); //Get headers
         pData.RemoveAt( 0 ); //Remove headers from the data

         string[] rep = pData.ElementAt( 0 );

         trainingData = getDataTypes( rep );
         testData = trainingData.ConvertAll<DataType>( item => (DataType)item.getNew() );

         Random rand = new Random();

         foreach( var row in pData ) {
            List<DataType> listToAdd;

            if( rand.NextDouble() < trainingPercent ) {
               listToAdd = trainingData;
            } else {
               listToAdd = testData;
            }

            for( int i = 0; i < row.Length; ++i ) {
               listToAdd.ElementAt( i ).add( row[i] );
            }
         }

         foreach( var temp in trainingData ) {
            Console.Write( temp.Count + " " );
         }
         Console.WriteLine();
         foreach( var temp in testData ) {
            Console.Write( temp.Count + " " );
         }
         Console.ReadKey();
      }

      private List<DataType> getDataTypes(string[] data)
      {
         List<DataType> classes = new List<DataType>( Utils.GetListOfClassesOfType<DataType>() );

         List<DataType> dataTypes = new List<DataType>();

         foreach( var item in data ) {
            foreach( var type in classes ) {
               if( type.isType( item ) ) {
                  dataTypes.Add( type.getNew() );
                  break;
               }

            }
         }
         return dataTypes;
      }
   }
}
