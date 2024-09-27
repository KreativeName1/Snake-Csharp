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

      Console.WriteLine("Use arrow keys to move");
      Console.WriteLine();

      Console.WriteLine("1. Start");
      Console.WriteLine("2. Quit");

      ConsoleKeyInfo key = Console.ReadKey(true);
      switch (key.Key)
      {
        case ConsoleKey.D1:
          Console.Clear();
          Choice();
          break;

        case ConsoleKey.D2:
          Environment.Exit(0);
          break;

        default:
          StartMenu();
          break;
      }
    }

    public void Choice()
    {
      int width = 0;
      int height = 0;
      int tickrate = 150;
      Console.WriteLine("1. Small");
      Console.WriteLine("2. Medium");
      Console.WriteLine("3. Big");
      Console.WriteLine("4. Custom");
      Console.WriteLine("5. Back");
      Console.WriteLine();
      ConsoleKeyInfo key = Console.ReadKey(true);
      switch (key.Key)
      {
        case ConsoleKey.D1:
          width = 20;
          height = 10;
          break;

        case ConsoleKey.D2:
          width = 50;
          height = 20;
          break;

        case ConsoleKey.D3:
          width = 100;
          height = 40;
          break;

        case ConsoleKey.D4:
          Console.Clear();
          while (true)
          {
            try { Console.Write("Width: "); width = Convert.ToInt32(Console.ReadLine()); break; }
            catch { Console.WriteLine("Input has to be a number."); }
          }
          while (true)
          {
            try { Console.Write("Height: "); height = Convert.ToInt32(Console.ReadLine()); break; }
            catch { Console.WriteLine("Input has to be a number."); }
          }
          while (true)
          {
            try { Console.Write("Tickrate: "); tickrate = Convert.ToInt32(Console.ReadLine()); break; }
            catch { Console.WriteLine("Input has to be a number."); }
          }
          break;

        case ConsoleKey.D5:
          StartMenu();
          break;

        default:
          Choice();
          break;
      }

      Console.Clear();
      new Game(width, height, tickrate);
      StartMenu();
    }

    private void Colored(string text, ConsoleColor color, bool newLine)
    {
      Console.ForegroundColor = color;
      if (newLine) { Console.WriteLine(text); }
      else { Console.Write(text); }
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}