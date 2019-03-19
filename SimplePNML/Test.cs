using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePNML
{
    public class Test
    {
        public static void Main(string[] args)
        {
            FileInfo file = new FileInfo(@"C:\Users\Koerfer\Downloads\philo.pnml");
            PNML pnml = PNML.Read(file);
        }

    }
}
