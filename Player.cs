namespace Snake
{
  public class Player : GameObject
  {
    public int Length { get; set; }
    public Queue<Position> Positions { get; set; }
    public ConsoleKeyInfo LastDirection { get; set; }

    public Player(int x, int y) : base(x, y, ConsoleColor.Green, '█')
    {
      Positions = new Queue<Position>();
      Length = 1;

      // Add Head to the Queue
      Positions.Enqueue(new Position(Position.x, Position.y));
    }

    // Move the player in the direction stored in LastDirection
    public void Move(ConsoleKeyInfo? key = null)
    {
      // if a key was pressed, change direction, otherwise continue in the same direction
      if (key.HasValue) LastDirection = key.Value;

      switch (LastDirection.Key)
      {
        case ConsoleKey.UpArrow: Position.y--; break;
        case ConsoleKey.DownArrow: Position.y++; break;
        case ConsoleKey.LeftArrow: Position.x--; break;
        case ConsoleKey.RightArrow: Position.x++; break;
      }
    }

    public void Eat()
    {
      Length++;
      Task.Run(() => Console.Beep(new Random().Next(800, 1500), 500));
    }

    public new void Draw()
    {
      // Draw the Head
      base.Draw();

      // Add new Position to the Queue
      Positions.Enqueue(new Position(Position.x, Position.y));

      // If the snake is longer than allowed, delete and overwrite the last part
      if (Positions.Count > Length)
      {
        Position pos = Positions.Dequeue();
        pos.Delete();
      }
    }

    public new void Delete()
    {
      foreach (Position pos in Positions) pos.Delete();
    }

    public bool IsCollidingSelf()
    {
      // Returns true if the snake is colliding with itself (except the head)
      return Positions.Take(Positions.Count - 1).Any(pos => pos.Equals(Position));
    }
  }
}