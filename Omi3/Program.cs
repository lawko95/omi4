﻿using System;
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
			var ls = new BodyObject[2];
			ls[0] = new BodyObject(new Vector(1, 0), 3000000000, new Vector(0, -0.01), "a");
			ls[1] = new BodyObject(new Vector(15, 0), 3000000000, new Vector(0, 0.01), "b");
			var f = new Form1(ls);
			Application.Run(f);
			var c = new Controller(ls, 1, 100, f);
        }
    }
}