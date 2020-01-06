namespace ChessKnight
{
  public class BoardCell
  {
    public BoardCell(int value, int x, int y)
    {
      Value = value;
      X = x;
      Y = y;
    }

    public static BoardCell operator+ (BoardCell a, BoardCell b)
    {
      int newValue;

      int newX = a.X + b.X;
      int newY = a.Y + b.Y;
      newValue = a.Value + b.Value;

      BoardCell c = new BoardCell(newValue, newX, newY);

      return c;
    }

    public int Value { get; }
    public int X { get; }
    public int Y { get; }
  }
}