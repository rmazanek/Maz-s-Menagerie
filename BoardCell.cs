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

    public int Value { get; }
    public int X { get; }
    public int Y { get; }
  }
}