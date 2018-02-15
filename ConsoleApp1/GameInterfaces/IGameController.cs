using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  interface IGameController
  {
		void NextTurn();
		void SelectTile();
		void SelectTileLocation();
		void PlacedTile();
  }
}
