using System;
using System.Collections.Generic;
namespace Omi3
{
	public class Controller
	{
		public BodyObject[] bodies;
        private Connection[] connections;
		private double timeStep;
        private int uper;
        private int prion;
        private int upercount;
        private bool heur;

		public Controller(BodyObject[] bs, double dt, bool _heur, int _uper = 0, int _prion = 0)
		{
			bodies = bs;
			timeStep = dt;
			makeConnections();
            uper = _uper;
            prion = _prion;
            upercount = 0;
            heur = _heur;
		}

		public BodyObject[] DoStep()
		{
            if (heur){
                if (upercount <= 2)
                {
                    calcNewForce(connections.Length, true);
                }
                else
                {
                    calcNewForce(prion, false);
                }
                if(upercount == 1){
                    Array.Sort(connections);
                }
                upercount += 1;
                if (upercount > uper)
                {
                    upercount = 0;
                }
            }
            else{
                calcNewForce(connections.Length, false);
            }
			doStep();
            return bodies;
        }

		private void makeConnections()
		{
            connections = new Connection[(bodies.Length * (bodies.Length - 1) / 2)];
			var tel = 0;
			for (int i = 0; i < bodies.Length; i++)
			{
				for (int j = i + 1; j < bodies.Length; j++)
				{
					var tb = new TwoBodies(bodies[i], bodies[j]);
                    var c = new Connection(new FDiv(), tb);
					connections[tel] = c;
					tel++;
				}
			}
		}

        private void calcNewForce(int count, bool update)
		{
            for (int i = 0; i < count; i++)
			{
                var c = connections[i];
                var tb = c.TB;
				var r = Math.Pow(tb.A.Location.Dist(tb.B.Location), 2.0);
				var g = 6.674 * Math.Pow(10.0, -11.0);
				var f = (tb.A.Mass * tb.B.Mass * g) / r;
                if (update){
                    c.Update(f);
                }
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
