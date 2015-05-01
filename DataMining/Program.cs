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

           DataSet ds = new DataSet( set );

           HardCoded hc = new HardCoded( ds.TrainingData );

           hc.train();

        }
    }
}
