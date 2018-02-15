using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  public interface ITile
  {
		int Form { get; set; }
		int Rotation { get; set; }
		string PlayerName { get; set; }
		ConsoleColor Color { get; set; }
	}
}
