using System;
using System.Collections.Generic;
using System.IO;

namespace ChessKnight
{
  public class Board
  {
    //private int value;
    //private int x;
    //private int y;

    //public int[] cell {get; set;}

    public List<BoardCell> BoardCells = new List<BoardCell>();

    public void CreateBoard()
    {
      BoardCells.Clear();
      BoardCells.Add(new BoardCell(0, 0, 0));
      int cellValue = 1;

      //Layer cell count... 1^2, 3^2-1^2, 5^2-3^2, 7^2-5^2...
      //DELETE THIS COMMENT WHEN DONE: for(int cellValue = (int)Math.Pow(2*(layer-1)+1,2); cellValue < (int)Math.Pow(2*(layer)+1,2); cellValue++)

      for (int layer = 1; layer < 3; layer++)
      {
        for (int m = 0; m <= layer; m++) // Right side to top right - x is constant
        {
          BoardCell cell = new BoardCell(cellValue++, layer, m);
          BoardCells.Add(cell);
          
//          foreach (int[] item in BoardCells)
//          {
//            for (int i = 0; i < item.Length; i++)
//            {
//              Console.Write(" " + item[i]);
//            }
//            
//            Console.WriteLine();
//          }
        }
        
        for (int n = layer - 1; n >= -layer; n--) //Top right to top left - y is constant
        {
          BoardCell cell = new BoardCell(cellValue++, n, layer);
          BoardCells.Add(cell);

//          foreach (int[] item in BoardCells)
//          {
//            for (int i = 0; i < item.Length; i++)
//            {
//              Console.Write(" " + item[i]);
//            }
//            
//            Console.WriteLine();
//          }  
        }

        for (int o = layer - 1; o >= -layer; o--) //Top left to bottom left - -x is constant
        {
          BoardCell cell = new BoardCell(cellValue++, -layer, o);
          BoardCells.Add(cell);

//          foreach (int[] item in BoardCells)
//          {
//            for (int i = 0; i < item.Length; i++)
//            {
//              Console.Write(" " + item[i]);
//            }
//            
//            Console.WriteLine();
//          }            
        }
        
        for (int p = -layer + 1; p <= layer; p++) //Bottom left to bottom right - -y is constant
        {
          BoardCell cell = new BoardCell(cellValue++, p, -layer);
          BoardCells.Add(cell);

//         foreach (int[] item in BoardCells)
//         {
//           for (int i = 0; i < item.Length; i++)
//           {
//             Console.Write(" " + item[i]);
//           }
//           
//           Console.WriteLine();
//         }     
        }

        for (int q = -layer + 1; q < 0; q++) //Bottom right to {layer,-1} - -y is constant
        {
          BoardCell cell = new BoardCell(cellValue++, layer, q);
          BoardCells.Add(cell);

//          foreach (int[] item in BoardCells)
//          {
//            for (int i = 0; i < item.Length; i++)
//            {
//              Console.Write(" " + item[i]);
//            }
//            
//            Console.WriteLine();
//          }
        }
      }
    }

    //public showBoard()
    //{
    //return BoardCells;
    //}
  }
}