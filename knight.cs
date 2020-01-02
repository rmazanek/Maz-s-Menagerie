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

    //Define list of next positions and prior positions as list of arrays
    List<int[,]> nextPosList = new List<int[,]>{};
    List<int[,]> oldPosList = new List<int[,]>{};
    
    //Knight constructor (taking starting position)
    public Knight(int value, int x, int y)
    {
      pos[0] = value;
      pos[1] = x;
      pos[2] = y;
    }
    
    //Knight constructor (no starting position given)
    public Knight()
    {
      int[] pos = new int[3] {0,0,0};
      
      value = pos[0];
      x = pos[1];
      y = pos[2];
    }

    //Populate next move list
    public List<int[,]> NextPosList()
    {
      
      //Add move
      //nextPosList.Add(pos);


      //List moves

      Console.WriteLine("Moves generated: {");
      foreach (var item in nextPosList)
      {
        Console.WriteLine(item.ToString()+",\n");
      }


      return nextPosList;
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