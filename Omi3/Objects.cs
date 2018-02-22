﻿using System;
namespace omiform
{
	public class BodyObject
	{
		public string Name;
		public Vector Location;
		public double Mass;
		public Vector Velocity;
		public Vector Force;
		public BodyObject(Vector location, double mass, Vector velocity, string name = "Generic")
		{
			Location = location;
			Mass = mass;
			Velocity = velocity;
			Force = new Vector(0.0, 0.0);
			Name = name;
		}

		public void ResetF()
		{
			Force = new Vector(0.0, 0.0);
		}

		public void AddF(Vector f)
		{
			Force = Force + f;
		}

		public void DoStep(double dt)
		{
			Velocity = Velocity + Force.Div(Mass).Mult(dt);
			Location = Location + Velocity.Mult(dt);
		}

		public static BodyObject operator +(BodyObject a, BodyObject b)
		{
			return new BodyObject(a.Location + b.Location, a.Mass + b.Mass, a.Velocity + b.Velocity);
		}

		public string Print()
		{
			return Name + ":: l = " + Location.Print() + ", v = " + Velocity.Print();
		}
	}

	public struct Vector
	{
		public double X;
		public double Y;

		public Vector(double x, double y)
		{
			X = x;
			Y = y;
		}

		public static Vector operator +(Vector a, Vector b)
		{
			return new Vector(a.X + b.X, a.Y + b.Y);
		}

		public static Vector operator *(Vector a, Vector b)
		{
			return new Vector(a.X * b.X, a.Y * b.Y);
		}

		public Vector Mult(double d)
		{
			return new Vector(X * d, Y * d);
		}

		public Vector Div(double d)
		{
			return new Vector(X / d, Y / d);
		}

		public double Dist(Vector v)
		{
			return Math.Sqrt(Math.Pow(X - v.X, 2.0) + Math.Pow(Y - v.Y, 2.0));
		}

		public Vector Dir(Vector v)
		{
			var x = X - v.X;
			var y = Y - v.Y;
			var vec = new Vector(x, y);
			vec.Norm();
			return vec;
		}

		public void Norm()
		{
			var l = Math.Sqrt(Math.Pow(X, 2.0) + Math.Pow(Y, 2.0));
			X = X / l;
			Y = Y / l;
		}

		public string Print()
		{
			return "(" + X + ", " + Y + ")";
		}
	}

	public struct TwoBodies
	{
		public BodyObject A;
		public BodyObject B;

		public TwoBodies(BodyObject a, BodyObject b)
		{
			A = a;
			B = b;
		}
	}
}
