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

    public List<int[]> boardCells = new List<int[]>
    {
      new int[] {0,0,0}
    };

    public void createBoard(int maxLayers)
    {
      boardCells.Clear();
      boardCells.Add(new int[] {0,0,0});
      int cellValue = 1;
      int layer;

      //Layer cell count... 1^2, 3^2-1^2, 5^2-3^2, 7^2-5^2...
      //DELETE THIS COMMENT WHEN DONE: for(int cellValue = (int)Math.Pow(2*(layer-1)+1,2); cellValue < (int)Math.Pow(2*(layer)+1,2); cellValue++)

      for (layer = 1; layer < maxLayers; layer++) //Change layers for a bigger board
      {
        for (int m = 0; m <= layer; m++) //Right side to top right - x is constant
        {
          int[] cell = new int[3];
          
          cell[0] = cellValue++;
          cell[1] = layer;
          cell[2] = m;

          boardCells.Add(cell);
          
//          foreach (int[] item in boardCells)
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
          int[] cell = new int[3];

          cell[0] = cellValue++;
          cell[1] = n;
          cell[2] = layer;

          boardCells.Add(cell);

//          foreach (int[] item in boardCells)
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
          int[] cell = new int[3];

          cell[0] = cellValue++;
          cell[1] = -layer;
          cell[2] = o;

          boardCells.Add(cell);

//          foreach (int[] item in boardCells)
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
          int[] cell = new int[3];

          cell[0] = cellValue++;
          cell[1] = p;
          cell[2] = -layer;

          boardCells.Add(cell);

//         foreach (int[] item in boardCells)
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
          int[] cell = new int[3];

          cell[0] = cellValue++;
          cell[1] = layer;
          cell[2] = q;

          boardCells.Add(cell);

//          foreach (int[] item in boardCells)
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
    //return boardCells;
    //}
  }
}