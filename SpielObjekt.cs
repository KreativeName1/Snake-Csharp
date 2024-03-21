namespace Snake
{
	public class SpielObjekt
	{
		public Position Position { get; set; }
		public ConsoleColor Farbe { get; set; }
		public char Zeichen { get; set; }

		public SpielObjekt(int x, int y, ConsoleColor farbe, char zeichen)
		{
			Position = new Position(x, y);
			Farbe = farbe;
			Zeichen = zeichen;
		}

		public void Zeichnen()
		{
			Console.SetCursorPosition(Position.x, Position.y);
			Console.ForegroundColor = Farbe;
			Console.Write(Zeichen);
			Console.ForegroundColor = ConsoleColor.White;
		}

		public void Löschen()
		{
			Console.SetCursorPosition(Position.x, Position.y);
			Console.Write(" ");
		}

		public bool IstKollision(SpielObjekt spielObjekt)
		{
			return Position.Equals(spielObjekt.Position);
		}

		public bool IstKollision(List<SpielObjekt> spielObjekte)
		{
			return spielObjekte.Any(spielObjekt => IstKollision(spielObjekt));
		}
	}
}