using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  public interface IPlayerController
  {
		IPlayer PlayerOne { get; set; }
		IPlayer PlayerTwo { get; set; }
		IPlayer Current { get; set; }
		void NextTurn();
	}
}
