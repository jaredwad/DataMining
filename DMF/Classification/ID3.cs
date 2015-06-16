using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF.Classification
{
   class ID3
   {
//      private DataSet data;
      private List<string[]> trainingData;
      private List<DataType> dataTypes;

      private List<ID3> children;
      private ID3 parent;

      private double entropy;

      public ID3(DataSet pData)
      {
//         data = pData;
         trainingData = pData.TrainingData;
         dataTypes = pData.DataTypes;
      }

      public ID3( List<string[]> pData, List<DataType> pDataTypes, ID3 pParent = null )
      {
         trainingData = pData;
         dataTypes = pDataTypes;
         parent = pParent;
      }

      private double getEntropy(string[] pSet, string[] pClasifications, DataType pType)
      {
         pSet = pType.normalize( pSet );
         List<string> uniqueClassifiers = pClasifications.Distinct().ToList();
         List<string> uniqueSets = pSet.Distinct().ToList();
         List<int> count = new List<int>();
         int size = pSet.Count();

         /////
         // Initialize count
         /////
         foreach(string temp in uniqueClassifiers) {
            count.Add( 0 );
         }

         for( int i = 0; i < size; ++i ) {

         }


            return 1;
      }

   }
}
