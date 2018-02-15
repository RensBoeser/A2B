using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  public interface IDrawManager
  {
		void DrawBoard(IBoard board);
		void DrawDice(IPlayer playerOne, IPlayer playerTwo);
		void DrawDeck(IPlayer playerOne, IPlayer playerTwo);
		void DrawText(string text);
  }
}
