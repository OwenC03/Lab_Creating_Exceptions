
namespace Creating_Exceptions
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				// testing objects as the lab directs... 

				// positive radius test
				Circle circle1 = new Circle(8);
				Console.WriteLine(circle1);

				// negative radius test
				try
				{
					Circle circle2 = new Circle(-4);
					Console.WriteLine(circle2);
				}
				catch (InvalidRadiusException ex)
				{
					Console.WriteLine(ex.Message);
				}

				// radius of 0 test

				try
				{
					Circle circle3 = new Circle(0);
					Console.WriteLine(circle3);
				}
				catch (InvalidRadiusException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			catch (InvalidRadiusException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex)  
			{
				Console.WriteLine("An unexpected error occurred: " + ex.Message);
			}
		}
	}
	class Circle
	{
		private double radius;

		public Circle(double radius)
		{
			SetRadius(radius);
		}

		public void SetRadius(double radius)
		{
			Console.WriteLine($"Setting radius: {radius}");
			if (radius <= 0)
			{
				throw new InvalidRadiusException(radius);
			}
			
			this.radius = radius;
		}

		public override string ToString()
		{
			return $"Circle with radius {radius}";
		}
	}


	class InvalidRadiusException : Exception
	{
		public InvalidRadiusException() : base("Radius should be greater than zero.") { }
		public InvalidRadiusException(double radius) : base($"Invalid radius: {radius}. Radius should be greater than zero.") { }
	}
}
