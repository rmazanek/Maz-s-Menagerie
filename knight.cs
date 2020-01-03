using System;
using System.Collections.Generic;
using System.IO;

namespace ChessKnight
{
  
  public class Knight
  {
    private int value;
    private int x;
    private int y;
    public int[] pos {get; set;}

    /*Define list of translations (combinations of x and y moves), 
      next positions, and prior positions as list of arrays
    */
    
    public List<int[]> moves = new List<int[]>
    {
      new int[] {0,2,1},
      new int[] {0,-2,1},
      new int[] {0,2,-1},
      new int[] {0,-2,-1},
      new int[] {0,1,2},
      new int[] {0,-1,2},
      new int[] {0,1,-2},
      new int[] {0,-1,-2}
      
    };    
    public List<int[]> nextPosList = new List<int[]>{};
    public List<int[]> oldPosList = new List<int[]>{};
        
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
      int[] pos = new int[3] {0,0,0};
      
      value = pos[0];
      x = pos[1];
      y = pos[2];

      oldPosList.Add(pos);
    }

    //Populate next move list
    public void NextPosList()
    {

      //Add move
      for (int i = 0; i < moves.Count; i++)
      {
        int[] move = new int[3] {0,0,0};
        int[] startingPoint = new int[3] {0,0,0};
        int[] endingPoint = new int[3] {0,0,0};
      
      startingPoint = pos;
      move = moves[i];

      endingPoint[1] = startingPoint[1] + move[1];
      endingPoint[2] = startingPoint[2] + move[2];

      nextPosList.Add(endingPoint);
      }

      //List moves
      Console.WriteLine("Moves generated: value, x position, y position");
      foreach (var item in nextPosList)
      {
        for (int i = 0; i < item.Length; i++)
        {
          Console.Write(" " + item[i]);
        }
        
        Console.WriteLine();
      }
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
}