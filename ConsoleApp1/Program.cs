using System;
using System.Collections.Generic;

namespace Akkers2Beurs
{
  class Program
  {

    static void Main(string[] args)
    {
			List<int> amount = new List<int>() { 12, 10, 8, 6 };
			
			IPlayer playerOne = new Player("henk", ConsoleColor.Blue, amount);
			IPlayer playerTwo = new Player("harry", ConsoleColor.Red, amount);
			IBoard board = new Board(8, 8);
			IDrawManager drawManager = new TerminalDrawManager();

			IGameController gameController = new GameController(drawManager, playerOne, playerTwo, board);

			gameController.NextTurn();
    }
  }
}
