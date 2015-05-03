using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMF;
using DMF.Classification;

namespace DataMining
{
    class Program
    {
        static void Main(string[] args)
        {

           string[] temp = { "1.0", "yes", "2.0", "blue" };

           List<string[]> set = new List<string[]>();

           for( int i = 0; i < 10; ++i ) {
              set.Add( temp );
           }

           set = CSV.parseCSV( @"C:\Users\Jared Wadsworth\Documents\Visual Studio 2013\Projects\DataMining\DMF\Data\Car.csv" );

           DataSet ds = new DataSet( set );

           Knn hc = new Knn( ds.TrainingData, 7 );

           hc.train();

           double accuracy = hc.test( ds.TestData );

           Console.WriteLine( "Accuracy = {0}", accuracy );

           Console.ReadKey();
        }
    }
}
