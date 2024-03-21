namespace Snake
{
	public class Spieler : SpielObjekt
	{
		public int Länge { get; set; }
		public Queue<Position> Koordinaten { get; set; }
		public ConsoleKeyInfo LetzteRichtung { get; set; }

		public Spieler(int x, int y) : base(x, y, ConsoleColor.Green, '█')
		{
			Koordinaten = new Queue<Position>();
			Länge = 1;

			// Kopf des Spielers in die Queue einfügen
			Koordinaten.Enqueue(new Position(Position.x, Position.y));
		}

		// Bewegt den Spieler in die Richtung, die in LetzteRichtung gespeichert ist
		public void Bewegen(ConsoleKeyInfo? key = null)
		{
			// Wenn ein Key übergeben wurde, wird die Richtung geändert,
			// ansonsten wird die letzte Richtung verwendet
			if (key.HasValue) LetzteRichtung = key.Value;

			switch (LetzteRichtung.Key)
			{
				case ConsoleKey.UpArrow: Position.y--; break;
				case ConsoleKey.DownArrow: Position.y++; break;
				case ConsoleKey.LeftArrow: Position.x--; break;
				case ConsoleKey.RightArrow: Position.x++; break;
			}
		}

		public void Essen()
		{
			Länge++;
			// Beep im Hintergrund abspielen lassen (async)
			Task.Run(() => Console.Beep(new Random().Next(800, 1500), 500));
		}

		public new void Zeichnen()
		{
			// Kopf zeichnen
			base.Zeichnen();

			// Neue Position in die Schlange einfügen
			Koordinaten.Enqueue(new Position(Position.x, Position.y));

			// Wenn die Schlange länger als erlaubt ist, den letzen Teil löschen und überschreiben
			if (Koordinaten.Count > Länge)
			{
				Position pos = Koordinaten.Dequeue();
				pos.Löschen();
			}
		}

		public new void Löschen()
		{
			foreach (Position pos in Koordinaten) pos.Löschen();
		}

		public bool SelbstKollision()
		{
			// Holt die Anzahl der Elemente in der Schlange und zieht 1 ab, da der Kopf nicht mit sich selbst kollidieren kann
			return Koordinaten.Take(Koordinaten.Count - 1).Any(pos => pos.Equals(Position));
		}
	}
}