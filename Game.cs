namespace Snake
{
  public class Game
  {
    private Player player;
    private Food food;
    private int width;
    private int height;
    private int tickrate;

    public Game(int width, int height, int tickrate)
    {
      Console.CursorVisible = false;

      // Set Game-Window Size
      if (width > Console.WindowWidth - 2) width = Console.WindowWidth - 2;
      if (height > Console.WindowHeight - 6) height = Console.WindowHeight - 6;
      this.width = width;
      this.height = height;

      // Set Tickrate (Game-Speed)
      this.tickrate = tickrate;

      // Set Payer-Startposition
      player = new Player(this.width / 2, this.height / 2);

      // Set Food-Startposition
      food = new Food();
      food.Create(this.width, this.height, player.Positions);

      // Draw Game-Field and start Game-Loop
      DrawBorder();
      Update();
    }

    public void DrawBorder()
    {
      Console.ForegroundColor = ConsoleColor.Magenta;

      // Draw Border (top and bottom)
      for (int i = 0; i < width + 1; i++)
      {
        Console.SetCursorPosition(i, 0);
        Console.Write("█");
        Console.SetCursorPosition(i, height);
        Console.Write("█");
      }

      // Draw Border (left and right)
      for (int i = 0; i < height; i++)
      {
        Console.SetCursorPosition(0, i);
        Console.Write("█");
        Console.SetCursorPosition(width, i);
        Console.Write("█");
      }
    }

    public void Update()
    {
      food.Draw();

      while (true)
      {
        // if a key was pressed, change direction, otherwise continue straight
        if (Console.KeyAvailable) { player.Move(Console.ReadKey(true)); player.Draw(); }
        else { player.Move(); player.Draw(); }

        // if the player hits the edge, end the game
        if (player.Position.x == 0 || player.Position.x == width || player.Position.y == 0 || player.Position.y == height)
        {
          EndGame();
          break;
        }

        // if the player hits the food, increase points and create new food
        if (food.IsColliding(player))
        {
          player.Eat();
          food.Create(width, height, player.Positions);
          food.Draw();
        }

        // if the player hits itself, end the game
        if (player.IsCollidingSelf()) { EndGame(); break; }

        // Tickrate in ms
        Thread.Sleep(tickrate);
      }
    }

    public void Output(string message)
    {
      Console.SetCursorPosition(0, height + 2);
      Console.Write(message);
    }

    public void EndGame()
    {
      player.Delete();
      food.Delete();
      Console.ForegroundColor = ConsoleColor.Red;
      Output("You lost! Length: " + player.Length);
      Console.Beep(100, 500);
      Console.ReadKey();
    }
  }
}