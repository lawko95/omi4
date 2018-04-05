using System;
namespace Omi3
{
    public static class Helper
    {
        public static double CalcDistAbs(BodyObject[] a, BodyObject[] b){
            double res = 0.0;
            for (int i = 0; i < a.Length && i < b.Length; i++){
                res += Math.Pow(a[i].Location.Dist(b[i].Location), 2);
            }
            return res;
		}

        // use this one
        public static double CalcXoXt(BodyObject[] t0, BodyObject[] bf, BodyObject[] h){
            double res = 0;
            for (int i = 0; i < t0.Length; i++){
                var dx = Math.Abs(bf[i].Location.Dist(h[i].Location));
                var dxt = Math.Abs(t0[i].Location.Dist(bf[i].Location));
                var br = Math.Pow(dx / dxt, 2);
                res += br;

            }
            return Math.Sqrt(res) / t0.Length;
        }

        public static double Score(Controller c, Controller t){
            var dis = Helper.TotalDist(c.bodies);
            return Helper.CalcDistRel(c.bodies, t.bodies) / (dis * (dis * (dis - 1) / 2));
        }

        // and this one
		public static double EPres(BodyObject[] a, BodyObject[] b)
		{
			double ae = 0.0;
            double be = 0.0;
			for (int i = 0; i < a.Length && i < b.Length; i++)
			{
				ae += 0.5 * a[i].Mass * Math.Pow(a[i].Velocity.Lenth(), 2);
				be += 0.5 * b[i].Mass * Math.Pow(b[i].Velocity.Lenth(), 2);
			}
            var g = 6.674 * Math.Pow(10.0, -11.0);
            for (int i = 0; i < a.Length; i++){
                for (int j = 0; j < a.Length; j++){
                    if (i != j)
                    {
						ae -= (g * a[i].Mass * a[j].Mass) / a[i].Location.Dist(a[j].Location);
						be -= (g * b[i].Mass * b[j].Mass) / b[i].Location.Dist(b[j].Location);
                    }    
                }
            }
            return Math.Abs(ae - be) / be;
        }

		public static double CalcDistRel(BodyObject[] a, BodyObject[] b)
		{
			double res = 0.0;
			for (int i = 0; i < a.Length && i < b.Length; i++)
			{
				for (int j = 0; j < a.Length && j < b.Length; j++)
				{
                    res += Math.Pow(a[i].Location.Dist(a[j].Location) - b[i].Location.Dist(b[j].Location), 2);
				}
			}
			return res;
		}

        public static BodyObject[] CopyObjectList(BodyObject[] l){
            var res = new BodyObject[l.Length];
            for (int i = 0; i < l.Length; i++){
                res[i] = l[i].Copy();
            }
            return res;
        }

        public static double TotalDist(BodyObject[] l){
            double res = 0.0;
            foreach(BodyObject b in l){
                res += b.TDist;
            }
            return res;
        }

        public static BodyObject[] bodyObjectList(int i)
        {
            var ls = new BodyObject[i];
            Random rnd = new Random();
            for(int j = 0; j < i;j++)
            {
                ls[j] = new BodyObject(new Vector(rnd.Next(-250, 250), rnd.Next(-250, 250)), (double)rnd.Next(5, 100) * 100000000.0, new Vector(rnd.NextDouble() - 0.5, rnd.NextDouble() - 0.5));
            }
            return ls;
        }

        public static double DToString(double d){
            d *= 1;
            if (d < 0.0001){
                return 0.0;
            }
            return d;
        }
    }
}


/*
public static double CalcDistRel(BodydObject[] a, BodyObject[] b){
	double res = 0.0;
	for (int i = 0; i < a.Length && i < b.Length; i++){
		for (int j = 0; j < a.Length &&j < b.Length; j++){
			//res += Math.Abs()
		}
	}
	return res;
}*/
