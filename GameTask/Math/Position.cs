namespace GameTask.Math
{
	public class Position
	{
		public Position(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}
		public int X { get; set; }
		public int Y { get; set; }
		public void Set(Position position)
		{
			X = position.X;
			Y = position.Y;
		}
		public float Distance(Position coordinates)
		{
			return MathF.Sqrt((float)((X - coordinates.X) * (X - coordinates.X)) + (Y - coordinates.Y) * (Y - coordinates.Y));
		}
		public override string ToString()
		{
			return $"{{{X}:{Y}}}";
		}
	}
}
