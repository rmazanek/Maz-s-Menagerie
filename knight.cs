using System;
using System.Collections.Generic;
using System.IO;

namespace ChessKnight
{
  
  public class Knight
  {
    public BoardCell position;
    public BoardCell nextMove;
    public Board repeatBoard = new Board();
    public int layersAgain = Program.maxLayers;
    
    //private int value;
    //private int x;
    //private int y;
    //public int[] pos {get; set;}

    /*Define list of translations (combinations of x and y moves), 
      next positions, and prior positions as list of arrays
    */
    
    public List<BoardCell> moves = new List<BoardCell>
    {
      new BoardCell(0,2,1),
      new BoardCell(0,1,2),
      new BoardCell(0,-1,2),
      new BoardCell(0,-2,1),
      new BoardCell(0,-2,-1),
      new BoardCell(0,-1,-2),
      new BoardCell(0,1,-2),
      new BoardCell(0,2,-1)
    };    
    public List<BoardCell> nextPosList = new List<BoardCell>{};
    public List<BoardCell> oldPosList = new List<BoardCell>{};

        //Knight constructor (taking starting position)
    //public Knight(int value, int x, int y)
    //{
    //  pos[0] = value;
    //  pos[1] = x;
    //  pos[2] = y;
    //
    //  oldPosList.Add(pos);
    //}
    
    //Knight constructor (no starting position given)
    public Knight()
    {
      position = new BoardCell(0,0,0);
      oldPosList.Add(position);

      //KnightCell origin = new KnightCell();
      
      //value = pos[0];
     // x = pos[1];
     // y = pos[2];

     // oldPosList.Add(pos);
    }

    //Populate next move list

  }
    
    //return "{"+pos[0]+","+pos[1]+","+pos[2]+"}";
    
    //Set up public get and set methods for each in
    //public int[] Pos {get; set;}
    //public int[,] NextPosList {get; set;}
    //
    //public Knight()
    //{
    //  
    //  //Set each element of the origin position to {0,0,0}
    //  for (int i = 0; i < 2; i++)
    //  {
    //    originPos[i] = 0;    
    //  } 
    //  
    //  //Set current position to origin
    //  pos = originPos;
    //}
    //
    //private int[] NextPos(int[] pos)
    //{
    //  //NextPos[0,1] += pos[1]+1;
    //  //NextPos[1,] += pos[1]+1;
    //  return nextPos[0]; 
    //}
}