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
