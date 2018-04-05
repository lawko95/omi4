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
            int tests   = 20;
            int n       = 20;
            int steps   = 2000;
            int nln = n + (int)Math.Log(n);
            var sw = new System.Diagnostics.Stopwatch();
            for (int it = 0; it < tests; it++)
            {
                var ksControl = Helper.bodyObjectList(n);
                var ksTest = Helper.CopyObjectList(ksControl);
                var ksBF = Helper.CopyObjectList(ksControl);
				var ct = new Controller(ksTest, 1, true, nln, n);
                var cbf = new Controller(ksBF, 1, false, nln, n);
				sw.Start();
                for (int i = 0; i < steps; i++)
                {
                    ct.DoStep();
                    cbf.DoStep();
                    if (i % 100 == 2)
                    {
                        Console.Write(Helper.DToString(Helper.CalcXoXt(ksControl, cbf.bodies, ct.bodies)) + ",");
                        //Console.Write(Helper.DToString(Helper.EPres(ksControl, ct.bodies)) + ",");
                    }
                }
                sw.Stop();
                Console.WriteLine();
            }
            Console.ReadLine();
            /*
			var f = new Form1(c);
			Application.Run(f);*/
        }
    }
}
