using System;
using System.Drawing;
namespace Omi3
{
    //test
    public class Space
    {
        private int x;
        private int y;
        private Point middle;
        private double zoom;
        public Space(int _x, int _y, double _zoom)
        {
            x = _x;
            y = _y;
            middle = new Point(x / 2, y / 2);
            zoom = _zoom;
		}

		public Bitmap Make(BodyObject[] elems)
		{
			var bm = new Bitmap(x, y);
			foreach (BodyObject b in elems)
			{
				var p = vtp(b.Location);
                Console.WriteLine(b.Location.Print());
                if (inBound(p))
                {
                    bm.SetPixel(p.X, p.Y, Color.Red);
                }
                else{
                    Console.WriteLine(p.X + ", " + p.Y);
                }
			}
			return bm;
		}

        private bool inBound(Point p){
            return !(p.X < 0 || p.X >= x || p.Y < 0 || p.Y >= y);
        }

        public void ZoomIn(){
            zoom *= 1.1;
        }

        public void ZoomOut(){
            zoom *= 0.9;
        }

        private Point vtp(Vector p){
            double nx = p.X * zoom + (double) middle.X;
            double ny = p.Y * zoom + (double)middle.Y;
            return new Point((int) nx, (int) ny);
        }
    }
}
