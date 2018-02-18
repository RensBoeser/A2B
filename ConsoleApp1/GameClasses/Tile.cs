using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
	//forms:
	//-1:empty 0:straight 1:turn 2:tcross 3:cross
	public class Tile : ITile
	{
		public int Form { get; set; }
		public int Rotation { get; set; }
		public string PlayerName { get; set; }
		public ConsoleColor Color { get; set; }

		public Tile()
		{
			Form = -1;
			Rotation = -1;
			PlayerName = "null";
			Color = ConsoleColor.Black;
		}

		public Tile(int form, IPlayer player, int rotation=0)
		{
			Form = form;
			Rotation = rotation;
			PlayerName = player.Name;
			Color = player.Color;
		}
	}
}
