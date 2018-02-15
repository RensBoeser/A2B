using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
	public interface IBoard
  {
		void SetTile(int x, int y, ITile tile);
		void RotateTile(int x, int y, int rotation);
		void RemoveTile(int x, int y);
		void SetBridge(int x, int y, int rotation);
		ITile[,] GetBoard();
	}
}
