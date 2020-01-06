using System;
using System.Collections.Generic;
using System.Threading;

namespace ChessKnight 
{
  class Program 
  {
    public static Knight k = new Knight();
    public static Board b = new Board();
    public static int maxLayers = 5;  //Default board radius
    public static int valueFound;

    static void Main(string[] args) 
    {
      
     //List of commands
      List<string> userCmdList = new List<string> {
      "position",
      "do all",
      "do 1",
      "list moves",
      "create board -n (replace 'n' with integer number of cells representing maximum distance from origin)",
      "show board",
      "exit"
      };  
              
      bool shouldContinue = true; //Start the condition to keep the command line popping up until "exit" is entered
    
      b.createBoard(maxLayers); //Create default board 
         
      while(shouldContinue) //Request command from the user until "exit" is entered by user (thereby setting shouldContinue to false)
      {

        Console.Write("Enter command: "); //Command request and read command 
        
        //string input = Console.ReadLine().ToLower();
        string userCmd = Console.ReadLine().ToLower();;

        //try
        //{
        //  
        //  string[] argumentCmd = input.Split(" -",2,StringSplitOptions.RemoveEmptyEntries);
        //  userCmd = argumentCmd[0];
        //  
        //  layer = int.Parse(argumentCmd[1]);
        //  //DELETE WHEN FINISHED: int layer = int.Parse(argumentCmd[1].ToString());
        //}
        //catch (System.IndexOutOfRangeException)
        //{
        //  userCmd = Console.ReadLine().ToLower();
        //}

        //Find the logic for command
        switch (userCmd) 
        {
        
          case "help": //List all commands
            foreach(string cmd in userCmdList) {
              Console.WriteLine(cmd);
              }
            break;

          case "position":
            Console.Write("The knight's current position is: ");
            DisplayCell(k.position);
            Console.WriteLine();
          break;
          
          
          case "do all": //Do all moves until the knight can no longer move
              Console.WriteLine("The knight will move as many times as it can:");
              //Thread.Sleep(1500);
              NextPosList(k,b);

              while(k.nextPosList.Count > 0)
              {
                MoveOnce(k,b);
              }

              //Thread.Sleep(500);
              //Console.ForegroundColor = ConsoleColor.Magenta;
              //Console.WriteLine("The knight is still going!");
              //Console.ResetColor();
              //Console.WriteLine("The knight made " +  + " moves before getting stuck.");
            break;
                 
          case "do 1": //Do just one move and list the choices, ranking, and selection
              MoveOnce(k,b);
            break;
        
        //Show all previous moves
          case "list moves":
              Console.Write("The knight's current position is: ");
              DisplayCell(k.position);
              Console.WriteLine();
              Console.Write("The knight's path was: \n");
              DisplayList(k.oldPosList);
            break;

        //Create board
          case "create board":
            b.createBoard(maxLayers); //One day I want to pass an argument to "maxLayers" to create a bigger board
            break;
          
        //List cells in board
          case "show board":
            Console.WriteLine("Cell value, x position, y position: ");
            var size = (int)Math.Sqrt(b.BoardCells.Count);
            var offset = size / 2;
            var displayGrid = new string[size, size];

            foreach (BoardCell item in b.BoardCells)
            {
              displayGrid[item.X + offset, item.Y + offset] = item.Value.ToString();
            }

            Console.WriteLine();
            
            for (int y = size - 1; y >= 0; y--)
            {
              for (int x = 0; x < size; x++)
              {
                Console.Write(displayGrid[x, y].PadLeft(4));
              }

              Console.WriteLine();
              Console.WriteLine();
            }

            break;
        
        //Exit
          case "exit":
            Console.WriteLine("Hope you had fun!");
            shouldContinue = false;
            break;
        
        //Catch invalid commands
          default:
            Console.WriteLine("Invalid command. Try 'help'.");
            break;
        }
      }
    }

    public static void findPositionValue(Board board, int x, int y)
    {
      valueFound = 0;

      foreach (BoardCell cell in board.BoardCells)
      {
        valueFound += cell.Value * Convert.ToInt32(cell.X == x && cell.Y == y); 
      }
    }

    public static void NextPosList(Knight knight, Board board)
    {
      knight.nextPosList.Clear();
      Console.Write("Making 8 moves from cell: ");
      DisplayCell(knight.position);
      Console.WriteLine();
      Console.WriteLine();

      //Add move
      foreach (BoardCell move in knight.moves)
      {
        int endX = knight.position.X + move.X;
        int endY = knight.position.Y + move.Y;
        findPositionValue(board,endX,endY);

        int endValue = valueFound;

        Console.WriteLine(endX + " = " + knight.position.X + " + " + move.X);
        Console.WriteLine(endY + " = " + knight.position.Y + " + " + move.Y);
        Console.WriteLine(endValue + " is the value on X and Y coordinates " + endX + " " + endY);

        BoardCell endPoint = new BoardCell(endValue, endX, endY);
        if(endPoint.Value == 0)
        {
          Console.WriteLine("Point at origin or not found on board. The point was not added to the list.");
          continue;
        }
        else
        {
        //endPoint.Value = cell.findPositionValue(endPoint.X, endPoint.Y);
        Console.WriteLine("Added point to list " + endPoint.Value + ", " + endPoint.X + ", " + endPoint.Y);
        Console.WriteLine();
        knight.nextPosList.Add(endPoint);
        }
      }
    }

    public static void DisplayCell(BoardCell item)
    {
      Console.Write(item.Value + " " + item.X + " " + item.Y);
    }

    public static void GetNextMove(Knight knight)
    {
      try
      { //Show list of cells before removing visited spots
        DisplayList(knight.nextPosList);
        List<BoardCell> oldPosListDummy = new List<BoardCell>(knight.oldPosList);
        List<BoardCell> nextPosListDummy = new List<BoardCell>(knight.nextPosList);

        //Throw out any positions already visited
        foreach (BoardCell visitedCell in oldPosListDummy)
        {
          Console.WriteLine();
          Console.Write("Comparing ");
          DisplayCell(visitedCell);
          Console.WriteLine(" from the old list to items in the next position list.");
          Console.WriteLine();

          foreach (BoardCell nextCell in nextPosListDummy)
          {
            Console.Write("To item: ");
            DisplayCell(nextCell);
            Console.WriteLine();

            if (nextCell.Value == visitedCell.Value)
            {
              //BoardCell removeCell = new BoardCell(nextCell.Value,0,0);
              //knight.nextPosList.FindIndex(0,1,nextCell);

              //int index = knight.nextPosList.FindIndex(0,1,nextCell.Equals);
              //Console.WriteLine(index);
              //knight.nextPosList.Remove(knight.nextPosList[index]);

              Console.WriteLine("Items are equal! Let's remove this from the list of next positions.");
              knight.nextPosList.Remove(nextCell);
              Console.WriteLine("Old positions: ");
              DisplayList(knight.oldPosList);
              Console.WriteLine("Next positions, with one removed hopefully: ");
              DisplayList(knight.nextPosList);
              Console.WriteLine();
              Console.WriteLine("Continuing with the comparisons:");
              break;
            }
            else
            {
              Console.WriteLine("Items are not equal. Moving on.");
              continue;
            }
          }
        }
        //Rank the remaining positions
        knight.nextMove = knight.nextPosList[0];

        Console.WriteLine();
        Console.Write("Let's determine a winning move. Start comparing to first move in list: ");
        DisplayCell(knight.nextMove);
        Console.WriteLine();

        foreach (BoardCell cell in knight.nextPosList)
        {

          BoardCell temp = knight.nextMove;

          if(cell.Value < temp.Value)
          {
            Console.Write("Compared " );
            DisplayCell(cell);
            Console.Write(" and ");
            DisplayCell(temp);

            Console.Write(", finding the winner to be ");
            knight.nextMove = cell;
            DisplayCell(knight.nextMove);
            Console.WriteLine(" - true step");
          }
          else
          {
            Console.Write("Compared " );
            DisplayCell(cell);
            Console.Write(" and ");
            DisplayCell(temp);

            Console.Write(", finding the winner to be ");
            DisplayCell(knight.nextMove);
            Console.WriteLine(" - false step");
          }
        }
        Console.WriteLine();
        Console.WriteLine("We're done comparing. \n");

        knight.position = knight.nextMove;
      }
      catch (System.ArgumentOutOfRangeException)
      {
        Console.WriteLine("The knight has been cornered. Its path was:");
        DisplayList(knight.oldPosList);
        Console.WriteLine();
        if(knight.nextPosList.Count > 0)
        {
          Console.WriteLine("The knight's next possible moves were:");
          DisplayList(knight.nextPosList);
          Console.WriteLine();
        }
        
      }
    }

    public static void DisplayList(List<BoardCell> list)
    {
      foreach (BoardCell item in list)
      {
        DisplayCell(item);
        Console.WriteLine();
      }
    }

    public static void MoveOnce(Knight knight, Board board)
    {
      NextPosList(knight, board); //Get a list of next possible positions
                          
      Console.WriteLine();
      Console.Write("The knight's current position is: ");
      DisplayCell(knight.position);
      
      Console.WriteLine();            
      Console.WriteLine("The knight considered these cells:"); //Print knights possible moves      
      GetNextMove(knight); //Get winning next move (lowest value)
      
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("The knight moves once, to cell: ");
      DisplayCell(knight.nextMove);
      Console.ResetColor();
      Console.WriteLine();
      knight.oldPosList.Add(knight.nextMove);
      knight.position = knight.nextMove;
    }
  }
}
