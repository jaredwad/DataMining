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
      private List<string[]> testData;
      private List<string>   headers;

      public List<DataType> TrainingData { get { return trainingData; } }
      public List<string[]> TestData     { get { return testData;     } }
      public List<string>   Headers      { get { return headers;      } }

      public DataSet( List<string[]> pData )
         : this( .7, .3, pData ) { }

      public DataSet( double trainingPercent, double testPercent, List<string[]> pData, bool normalize = true )
      {
         splitData( trainingPercent, testPercent, pData, normalize );
      }

      private List<string[]> normalize(List<string[]> pData)
      {
         List<DataType> temp = stringToDataType( pData );

         foreach( var item in temp ) {
            item.normalize();
         }

         return dataTypeToString( temp );
      }

      private List<DataType> stringToDataType( List<string[]> pData )
      {
         List<DataType> temp = getDataTypes( pData.ElementAt( 0 ) );

         foreach( var row in pData ) {
            for( int i = 0; i < row.Length; ++i ) {
               temp.ElementAt( i ).add( row[i] );
            }
         }

         return temp;
      }

      private List<string[]> dataTypeToString( List<DataType> pData )
      {
         int length = pData.ElementAt( 0 ).Count;
         List<string[]> temp = new List<string[]>( length );

         for( int i = 0; i < length; ++i ) {
            string[] row = new string[pData.Count];

            for( int j = 0; j < pData.Count; ++j ) {
               row[j] = pData.ElementAt( j ).getAt( i );
            }
            temp.Add( row );
         }

            return temp;
      }

      private void splitData( double trainingPercent, double testPercent, List<string[]> pData, bool pNormalize = true )
      {
         headers = new List<string>( pData.ElementAt( 0 ) ); //Get headers
         pData.RemoveAt( 0 ); //Remove headers from the data

         if( pNormalize ) {
            pData = normalize( pData );
         }

         if( trainingPercent + testPercent != 1.0 ) {
            throw new ArgumentException( string.Format( "Cannont split data into groups that dont add up to 1.0 ( 100% ) {0} + {1} = {3}",
               trainingPercent, testPercent, trainingPercent + testPercent ) );
         }



         string[] rep = pData.ElementAt( 0 );

         trainingData = getDataTypes( rep );
         testData = new List<string[]>();
         //         testData = trainingData.ConvertAll<DataType>( item => (DataType)item.getNew() );

         Random rand = new Random();

         foreach( var row in pData ) {
            if( rand.NextDouble() < trainingPercent ) {

               for( int i = 0; i < row.Length; ++i ) {
                  trainingData.ElementAt( i ).add( row[i] );
               }
            } else {
               testData.Add( row );
            }
         }
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
