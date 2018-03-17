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
            var ksControl = Helper.bodyObjectList(20);
            var ksTest = Helper.CopyObjectList(ksControl);
            var cc = new Controller(ksControl, 1, false, ksControl.Length, ksControl.Length);
			var ct = new Controller(ksTest, 1, true, ksTest.Length, ksTest.Length);
            for (int i = 0; i < 1000; i++){
                cc.DoStep();
                ct.DoStep();
                if(i % ksControl.Length == 2){
                    Console.WriteLine(Helper.CalcDistRel(cc.bodies, ct.bodies) / Math.Pow(Helper.TotalDist(cc.bodies), 2));
                }
            }
            Console.WriteLine("End");
            Console.WriteLine(Helper.TotalDist(cc.bodies));
            Console.WriteLine(Helper.TotalDist(ct.bodies));
            Console.WriteLine(Helper.CalcDistRel(cc.bodies, ct.bodies));
            /*
			var f = new Form1(c);
			Application.Run(f);*/
        }
    }
}
