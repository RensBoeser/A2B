using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  public interface IPlayer
  {
		string Name { get; set; }
		ConsoleColor Color { get; set; }
		IDeck Deck { get; set; }
		int Dice { get; set; }
	}
}
