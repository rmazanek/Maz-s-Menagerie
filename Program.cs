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
      "do all",
      "do 1",
      "list moves",
      "exit"
      };  
     
     /*Start the condition to keep the command line
     popping up until "exit" is entered*/
      bool shouldContinue = true;
     
     /*Request command from the user until "exit" is 
     entered by user (thereby setting shouldContinue to false)*/
      while(shouldContinue)
      {

      //Command request and read command  
        Console.Write("Enter command: ");
        string userCmd = Console.ReadLine();
        
        //Change command to lower case and find the logic for it
        switch (userCmd.ToLower()) 
        {
        
          //List all commands
          case "help":
            foreach(string cmd in userCmdList) {
              Console.WriteLine(cmd);
              }
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
              Console.WriteLine("The knight checked these cells:");
              //Print the next knight move (cell value, x, y)
              Console.WriteLine("The knight moves once, to cell:");
                        
            break;
        
        //Show all previous moves
          case "list moves":
              Console.WriteLine("The knight's path was: ");
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
