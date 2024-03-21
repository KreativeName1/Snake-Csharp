namespace Snake
{
	public class Position
	{
		public int x { get; set; }
		public int y { get; set; }

		public Position(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Position))
				return false;

			Position other = (Position)obj;
			return this.x == other.x && this.y == other.y;
		}

		public void Löschen()
		{
			Console.SetCursorPosition(x, y);
			Console.Write(" ");
		}
	}
}