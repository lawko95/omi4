﻿using System;
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
                var ps = dialate(p);
                var print = false;
                foreach (Point pi in ps) { 
                    if (inBound(pi))
                    {
                        bm.SetPixel(pi.X, pi.Y, Color.Red);
                    }
                    else
                    {
                        if (print)
                        {
                            Console.WriteLine(p.X + ", " + p.Y);
                            print = false;
                        }
                    }
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

        private Point[] dialate(Point p){
            Point[] res = {
				new Point(p.X + 1, p.Y + 1),
				new Point(p.X + 1, p.Y - 1),
				new Point(p.X + 1, p.Y + 0),
				new Point(p.X - 1, p.Y + 1),
				new Point(p.X - 1, p.Y - 1),
				new Point(p.X - 1, p.Y + 0),
				new Point(p.X + 0, p.Y + 1),
				new Point(p.X + 0, p.Y - 1),
				new Point(p.X + 0, p.Y + 0)};
            return res;
        }
    }
}
