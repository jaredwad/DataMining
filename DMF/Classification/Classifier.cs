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
      public abstract string classify( int index );

      public double test( List<string[]> pData )
      {
         int numCorrect   = 0;
         int numIncorrect = 0;

         foreach(var row in pData) {

            string category = classify( row );

            Console.WriteLine( "Attempted to classify a {0} as a {1}", row[row.Length - 1], category );

            if( category.Equals( row[row.Length - 1] ) ) {
               numCorrect++;
            } else {
               numIncorrect++;
            }
         }

            //Need to implement a test here

         return ( (double)numCorrect / (double)pData.Count );
      }

   }
}
