namespace Snake
{
  public class GameObject
  {
    public Position Position { get; set; }
    public ConsoleColor Color { get; set; }
    public char Character { get; set; }

    public GameObject(int x, int y, ConsoleColor color, char character)
    {
      Position = new Position(x, y);
      Color = color;
      Character = character;
    }

    public void Draw()
    {
      Console.SetCursorPosition(Position.x, Position.y);
      Console.ForegroundColor = Color;
      Console.Write(Character);
      Console.ForegroundColor = ConsoleColor.White;
    }

    public void Delete()
    {
      Console.SetCursorPosition(Position.x, Position.y);
      Console.Write(" ");
    }

    public bool IsColliding(GameObject gameObject)
    {
      return Position.Equals(gameObject.Position);
    }

    public bool IsColliding(List<GameObject> gameObject)
    {
      return gameObject.Any(gameObject => IsColliding(gameObject));
    }
  }
}