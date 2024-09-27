namespace Snake
{
  internal class Food : GameObject
  {
    public Food() : base(0, 0, ConsoleColor.Red, '■')
    {
    }

    public new void Draw()
    {
      Delete();
      base.Draw();
    }

    public void Create(int width, int height, Queue<Position> player)
    {
      // Set random position within the game field
      Random random = new Random();
      Position.x = random.Next(1, width - 1);
      Position.y = random.Next(1, height - 1);

      // Check if the position is already occupied by the player
      while (player.Contains(Position))
      {
        Position.x = random.Next(1, width - 1);
        Position.y = random.Next(1, height - 1);
      }
    }
  }
}