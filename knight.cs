using System;
using System.IO;

namespace ChessKnight
{
  public class Knight
  {
    /* Set up positions as an array of integers, 
    with form [value, x coordinate, y coordinate]*/
    
    /*Define: 
    origin position (later set to {0,0,0})
    current position
    next position*/

    private int[] originPos = new int[3];
    private int[] pos = new int[3];
    private int[] nextPos = new int[3];

    //Define list of next positions as an array of arrays
    private int[,] nextPosList = new int[8,3];
    
    //Set up public get and set methods for each in
    public int[] Pos {get; set;}
    public int[,] NextPosList {get; set;}

    public Knight()
    {
      
      //Set each element of the origin position to {0,0,0}
      for (int i = 0; i < 2; i++)
      {
        originPos[i] = 0;    
      } 
      
      //Set current position to origin
      pos = originPos;
    }

    private int[] NextPos(int[] pos)
    {
      //NextPos[0,1] += pos[1]+1;
      //NextPos[1,] += pos[1]+1;
      return nextPos[]; 
    }

  }
}