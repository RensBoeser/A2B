using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  public interface IDrawManager
  {
		void NextTurnScene(IBoard board, IPlayer playerOne, IPlayer playerTwo);
  }
}
