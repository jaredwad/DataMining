using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMF.Classification
{
   public abstract class Classifier
   {
      protected List<DataType> data;

      protected List<string> categories;

      public Classifier(List<DataType> pData)
      {
         data = pData;
      }

      public abstract bool train();
      public abstract string classify( string[] newRow ); // should another be added here as an int for testing?

      public double test( List<DataType> pData )
      {
         int numCorrect   = 0;
         int numIncorrect = 0;

         //Need to implement a test here

         return ( (double)numCorrect / (double)pData.Count );
      }

   }
}
