﻿using System;
namespace Omi3
{
	public class Controller
	{
		private BodyObject[] bodies;
		private TwoBodies[] connections;
		private double timeStep;

		public Controller(BodyObject[] bs, double dt, int steps)
		{
			bodies = bs;
			timeStep = dt;
			makeConnections();
		}

		public BodyObject[] DoStep()
		{
			calcNewForce();
			doStep();
            return bodies;
        }

		private void makeConnections()
		{
			connections = new TwoBodies[(bodies.Length * (bodies.Length - 1) / 2)];
			var tel = 0;
			for (int i = 0; i < bodies.Length; i++)
			{
				for (int j = i + 1; j < bodies.Length; j++)
				{
					var tb = new TwoBodies(bodies[i], bodies[j]);
					connections[tel] = tb;
					tel++;
				}
			}
		}

		private void calcNewForce()
		{
			foreach (TwoBodies tb in connections)
			{
				var r = Math.Pow(tb.A.Location.Dist(tb.B.Location), 2.0);
				var g = 6.674 * Math.Pow(10.0, -11.0);
				var f = (tb.A.Mass * tb.B.Mass * g) / r;
				var bta = tb.A.Location.Dir(tb.B.Location);
				var atb = tb.B.Location.Dir(tb.A.Location);
				bta = bta.Mult(f);
				atb = atb.Mult(f);
				tb.B.AddF(bta);
				tb.A.AddF(atb);
			}
		}

		private void doStep()
		{
			foreach (BodyObject b in bodies)
			{
				b.DoStep(timeStep);
				Console.WriteLine(b.Print());
				b.ResetF();
			}
		}
	}
}
