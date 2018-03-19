using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omi3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            // Inputs
            int tests = 10;
            int n =     20;
            int gens =  50;
            for (int it = 0; it < tests; it++)
            {
                var ksControl = Helper.bodyObjectList(n);
                var ksTest = Helper.CopyObjectList(ksControl);
                var cc = new Controller(ksControl, 1, false, ksControl.Length, ksControl.Length);
                var ct = new Controller(ksTest, 1, true, ksTest.Length, ksTest.Length);
                for (int i = 0; i < n * gens; i++)
                {
                    cc.DoStep();
                    ct.DoStep();
                    if (i % ksControl.Length == 2)
                    {
                        Console.Write(Helper.DToString(Helper.Score(cc, ct)) + ",");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            /*
			var f = new Form1(c);
			Application.Run(f);*/
        }
    }
}
