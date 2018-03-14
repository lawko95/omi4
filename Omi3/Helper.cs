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
    }
}
