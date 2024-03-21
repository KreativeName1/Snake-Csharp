namespace Snake
{
	internal class Essen : SpielObjekt
	{
		public Essen() : base(0, 0, ConsoleColor.Red, '■')
		{
		}

		public new void Zeichnen()
		{
			// Altes Essen löschen
			Löschen();

			// Neues Essen zeichnen
			base.Zeichnen();
		}

		public void Erzeugen(int breite, int hoehe, Queue<Position> spieler)
		{
			// Zufällige Position erzeugen innerhalb des Spielfeldes
			Random random = new Random();
			Position.x = random.Next(1, breite - 1);
			Position.y = random.Next(1, hoehe - 1);

			// Prüfen ob die Position bereits von dem Spieler belegt ist
			while (spieler.Contains(Position))
			{
				Position.x = random.Next(1, breite - 1);
				Position.y = random.Next(1, hoehe - 1);
			}
		}
	}
}