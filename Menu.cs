namespace Snake
{
	internal class Menu
	{
		public void StartMenu()
		{
			Console.Clear();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("=== SNAKE ===");
			Console.ForegroundColor = ConsoleColor.White;

			Console.WriteLine();

			Console.WriteLine("Pfeiltasten zum steuern");
			Console.WriteLine();

			Console.WriteLine("1. Start");
			Console.WriteLine("2. Beenden");

			ConsoleKeyInfo key = Console.ReadKey(true);
			switch (key.Key)
			{
				case ConsoleKey.D1:
					Console.Clear();
					Auswahl();
					break;

				case ConsoleKey.D2:
					Environment.Exit(0);
					break;

				default:
					StartMenu();
					break;
			}
		}

		public void Auswahl()
		{
			int breite = 0;
			int hoehe = 0;
			int tickrate = 150;
			Console.WriteLine("1. Klein");
			Console.WriteLine("2. Mittel");
			Console.WriteLine("3. Groß");
			Console.WriteLine("4. Benutzerdefiniert");
			Console.WriteLine("5. Zurück");
			Console.WriteLine();
			ConsoleKeyInfo key = Console.ReadKey(true);
			switch (key.Key)
			{
				case ConsoleKey.D1:
					breite = 20;
					hoehe = 10;
					break;

				case ConsoleKey.D2:
					breite = 50;
					hoehe = 20;
					break;

				case ConsoleKey.D3:
					breite = 100;
					hoehe = 40;
					break;

				case ConsoleKey.D4:
					Console.Clear();
					Console.WriteLine("Falls die Werte größer als die Konsole sind, wird es automatisch angepasst ans Fenster.");
					while (true)
					{
						try { Console.Write("Breite: "); breite = Convert.ToInt32(Console.ReadLine()); break; }
						catch { Console.WriteLine("Bitte eine Zahl eingeben."); }
					}
					while (true)
					{
						try { Console.Write("Höhe: "); hoehe = Convert.ToInt32(Console.ReadLine()); break; }
						catch { Console.WriteLine("Bitte eine Zahl eingeben."); }
					}
					while (true)
					{
						try { Console.Write("Tickrate: "); tickrate = Convert.ToInt32(Console.ReadLine()); break; }
						catch { Console.WriteLine("Bitte eine Zahl eingeben."); }
					}
					break;

				case ConsoleKey.D5:
					StartMenu();
					break;

				default:
					Auswahl();
					break;
			}

			Console.Clear();
			new Spiel(breite, hoehe, tickrate);
			StartMenu();
		}

		private void Farbig(string text, ConsoleColor farbe, bool newLine)
		{
			Console.ForegroundColor = farbe;
			if (newLine) { Console.WriteLine(text); }
			else { Console.Write(text); }
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}