using System;
namespace Omi3
{
    public static class Helper
    {
        public static double CalcDist(BodyObject[] a, BodyObject[] b){
            double res = 0.0;
            for (int i = 0; i < a.Length && i < b.Length; i++){
                res += Math.Pow(a[i].Location.Dist(b[i].Location), 2);
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
