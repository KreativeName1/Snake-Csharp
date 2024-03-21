namespace Snake
{
	public class Spiel
	{
		private Spieler spieler;
		private Essen essen;
		private int breite;
		private int hoehe;
		private int tickrate;

		public Spiel(int breite, int hoehe, int tickrate)
		{
			// Cursor verstecken
			Console.CursorVisible = false;

			// Spielfeldgröße setzen (2 zeilen unter dem Spielfeld muss noch platz sein)
			if (breite > Console.WindowWidth - 2) breite = Console.WindowWidth - 2;
			if (hoehe > Console.WindowHeight - 6) hoehe = Console.WindowHeight - 6;
			this.breite = breite;
			this.hoehe = hoehe;

			// Tickrate setzen
			this.tickrate = tickrate;

			// Spieler in der Mitte des Spielfeldes erzeugen
			spieler = new Spieler(this.breite / 2, this.hoehe / 2);

			// Essen erzeugen und auf dem Spielfeld platzieren
			essen = new Essen();
			essen.Erzeugen(this.breite, this.hoehe, spieler.Koordinaten);

			// Spielfeld zeichnen und Spiel-Loop starten
			RandZeichnen();
			Update();
		}

		public void RandZeichnen()
		{
			Console.ForegroundColor = ConsoleColor.Magenta;

			// Ausgabe des Randes (oben und unten)
			for (int i = 0; i < breite+1; i++)
			{
				Console.SetCursorPosition(i, 0);
				Console.Write("█");
				Console.SetCursorPosition(i, hoehe);
				Console.Write("█");
			}

			// Ausgabe des Randes (links und rechts)
			for (int i = 0; i < hoehe; i++)
			{
				Console.SetCursorPosition(0, i);
				Console.Write("█");
				Console.SetCursorPosition(breite, i);
				Console.Write("█");
			}
		}

		public void Update()
		{
			essen.Zeichnen();

			while (true)
			{
				// falls eine Taste gedrückt wurde, richtung ändern, sonst weiter geradeaus
				if (Console.KeyAvailable) { spieler.Bewegen(Console.ReadKey(true)); spieler.Zeichnen(); }
				else { spieler.Bewegen(); spieler.Zeichnen(); }

				// falls der Spieler auf den Rand trifft, Spiel beenden
				if (spieler.Position.x == 0 || spieler.Position.x == breite || spieler.Position.y == 0 || spieler.Position.y == hoehe)
				{
					Ende();
					break;
				}

				// falls der Spieler auf das Essen trifft, Punkte erhöhen und neues Essen erzeugen
				if (essen.IstKollision(spieler))
				{
					spieler.Essen();
					essen.Erzeugen(breite, hoehe, spieler.Koordinaten);
					essen.Zeichnen();
				}

				// falls der Spieler auf sich selbst trifft, Spiel beenden
				if (spieler.SelbstKollision()) { Ende(); break; }

				// Ausgabe der Länge und Position des Spielers
				Ausgabe("Länge: " + spieler.Länge + " Position: " + spieler.Position.x.ToString().PadLeft(2, '0') + ", " + spieler.Position.y.ToString().PadLeft(2, '0'));

				// Tickrate in ms
				Thread.Sleep(tickrate);
			}
		}

		public void Ausgabe(string message)
		{
			Console.SetCursorPosition(0, hoehe + 2);
			Console.Write(message);
		}

		public void Ende()
		{
			spieler.Löschen();
			essen.Löschen();
			Console.ForegroundColor = ConsoleColor.Red;
			Ausgabe("Du hast verloren! Erreichte Länge: " + spieler.Länge);
			Console.Beep(100, 500);
			Console.ReadKey();
		}
	}
}