using System;
using System.Collections.Generic;
using System.IO;

namespace ChessKnight
{
  public class Board
  {

    public List<BoardCell> BoardCells = new List<BoardCell>();

    public void createBoard(int maxLayers)
    {
      BoardCells.Clear();
      BoardCells.Add(new BoardCell(0, 0, 0));
      int cellValue = 1;
      int layer;

      //Layer cell count... 1^2, 3^2-1^2, 5^2-3^2, 7^2-5^2...

      for (layer = 1; layer < maxLayers; layer++) //Change layers for a bigger board
      {
        for (int m = -layer + 1; m < layer + 1; m++) //Right side to top right - x is constant
        {
          BoardCell cell = new BoardCell(cellValue++, layer, m);
          BoardCells.Add(cell);
        }
        
        for (int n = layer - 1; n >= -layer; n--) //Top right to top left - y is constant
        {
          BoardCell cell = new BoardCell(cellValue++, n, layer);
          BoardCells.Add(cell);
        }

        for (int o = layer - 1; o >= -layer; o--) //Top left to bottom left - -x is constant
        {
          BoardCell cell = new BoardCell(cellValue++, -layer, o);
          BoardCells.Add(cell);
        }
        
        for (int p = -layer + 1; p <= layer; p++) //Bottom left to bottom right - -y is constant
        {
          BoardCell cell = new BoardCell(cellValue++, p, -layer);
          BoardCells.Add(cell);
        }
      }
    }
  }
}