using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  public class Player : IPlayer
  {
		public string Name { get; set; }
		public ConsoleColor Color { get; set; }
		public IDeck Deck { get; set; }
		public int Dice { get; set; }

		public Player(string name, ConsoleColor color, List<int> amount)
		{
			Name = name;
			Color = color;
			Deck = new Deck(this, amount);
			Dice = new Random().Next(1, 6);
		}

		public void ThrowDice()
		{
			Dice = new Random().Next(1, 6);
		}
  }
}
