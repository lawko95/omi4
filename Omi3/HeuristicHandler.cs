using System;
namespace Omi3
{
	public class Connection : IComparable<Connection>
	{
		public double V;
		public TwoBodies TB;
		public Heuristic H;
		public Connection(Heuristic h, TwoBodies tb)
		{
			V = 0;
			TB = tb;
			H = h;
		}

		public void Update(double f)
		{
			V = H.Calc(TB, f);
		}

		public int CompareTo(Connection obj)
		{
			if (this.V > obj.V) return -1;
			return 1;
		}
	}

    public class Heuristic{
        public Heuristic(){
            
        }

        public virtual double Calc(TwoBodies tb, double f){
            return 0.0;
        }
    }

    public class FDiv : Heuristic{
        private double prefF;
        public FDiv() : base(){
            prefF = -1.0;
        }

        public override double Calc(TwoBodies tb, double f){
            if (prefF < 0){
                prefF = f;
                return 0.0;
            }
            else{
                double res = Math.Abs(prefF - f);
                prefF = f;
                return res;
            }
        }
    }
}
