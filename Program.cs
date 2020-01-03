using System;
using System.Collections.Generic;
using System.Threading;

namespace ChessKnight 
{
  class Program 
  {
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
     
     /*Start the condition to keep the command line
     popping up until "exit" is entered*/
      bool shouldContinue = true;
     
      Knight k = new Knight();
      Board b = new Board();

     /*Request command from the user until "exit" is 
     entered by user (thereby setting shouldContinue to false)*/
      while(shouldContinue)
      {

      //Command request and read command  
        Console.Write("Enter command: ");
        
        //string input = Console.ReadLine().ToLower();
        string userCmd = Console.ReadLine().ToLower();;
        int maxLayers = 10;  //Default to 10 board radius

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
        
        //DELETE WHEN FINISHED: Console.WriteLine($"{userCmd.Length} substrings in text:");
        //DELETE WHEN FINISHED: 
        //DELETE WHEN FINISHED: for (int c = 0; c < userCmd.Length; c++)
        //DELETE WHEN FINISHED: {
        //DELETE WHEN FINISHED:   Console.Write(userCmd[c] + "\n");
        //DELETE WHEN FINISHED: }


        //Change command to lower case and find the logic for it
        switch (userCmd)
        {
        
          //List all commands
          case "help":
            foreach(string cmd in userCmdList) {
              Console.WriteLine(cmd);
              }
            break;

          case "position":
            Console.WriteLine("The knight's current position is: " + k.pos[0]);
          break;
          
          //Do all moves until the knight can no longer move
          case "do all":
              Console.WriteLine("The knight will move as many times as it can:");
              //Thread.Sleep(1500);
              //Start printing knight moves (cell value, x, y)
              //Thread.Sleep(5000);
              Console.WriteLine("The knight is still going!");
              //Console.WriteLine("The knight made " +  + " moves before getting stuck.");
            break;
        
        /*Do just one move and list the choices, ranking, 
        and selection*/
          case "do 1":
              /*Print knights possible moves, ranked 
              (cell value, x, y)*/
              k.NextPosList();
              Console.WriteLine("The knight moves once, to cell:");
                        
            break;
        
        //Show all previous moves
          case "list moves":
              Console.WriteLine("The knight's path was: ");
            break;

        //Create board
          case "create board":
            b.CreateBoard(maxLayers);
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
  }
}
