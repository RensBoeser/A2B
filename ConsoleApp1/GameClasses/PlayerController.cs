using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  public class PlayerController : IPlayerController
  {
		public IPlayer PlayerOne { get; set; }
		public IPlayer PlayerTwo { get; set; }
		public IPlayer Current { get; set; }
		
		public PlayerController(IPlayer playerOne, IPlayer playerTwo)
		{
			PlayerOne = playerOne;
			PlayerTwo = playerTwo;
			Current = PlayerOne;
		}

		public void NextTurn()
		{

		}
	}
}
