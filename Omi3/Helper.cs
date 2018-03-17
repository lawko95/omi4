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
