using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF
{
   public class DataSet
   {
      private List<DataType> dataTypes;
      private List<string[]> trainingData;
      private List<string[]> testData;
      private List<string>   headers;

      public List<DataType> DataTypes    { get { return dataTypes;    } }
      public List<string[]> TrainingData { get { return trainingData; } }
      public List<string[]> TestData     { get { return testData;     } }
      public List<string>   Headers      { get { return headers;      } }

      public DataSet( List<string[]> pData, List<DataType> pDataTypes )
         : this( .7, .3, pData, pDataTypes ) { }

      public DataSet( double trainingPercent, double testPercent, List<string[]> pData, List<DataType> pDataTypes, bool normalize = true )
      {
         splitData( trainingPercent, testPercent, pData, normalize );
      }

      private List<string[]> normalize( List<string[]> pData ) { return normalize( pData, dataTypes ); }
      private List<string[]> normalize( List<string[]> pData, List<DataType> pDataTypes )
      {
         for( int i = 0; i < pData.Count; ++i ) {
            pData[i] = pDataTypes[i].normalize( pData[i] );
         }
            return pData;
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

         trainingData = new List<string[]>();
         testData = new List<string[]>();

         Random rand = new Random();

         foreach( var row in pData ) {
            if( rand.NextDouble() < trainingPercent ) {
               trainingData.Add( row );
            } else {
               testData.Add( row );
            }
         }
      }
   }
}
