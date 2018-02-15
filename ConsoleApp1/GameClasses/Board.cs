using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
    public class Board : IBoard
    {
		ITile[,] Grid;

		public Board(int dimentionX, int dimentionY)
		{
			Grid = new Tile[dimentionX, dimentionY];
			for (int i = 0; i < Grid.GetLength(1); i++)
			{
				for (int j = 0; j < Grid.GetLength(0); j++)
				{
					Grid[i, j] = new Tile();
				}
			}
		}

		public void SetTile(int x, int y, ITile tile)
		{
			Grid[x, y] = tile;
		}

		public void RotateTile(int x, int y, int rotation)
		{
			if (Grid[x, y].Form != -1)
			{
				Grid[x, y].Rotation = rotation;
			}
		}

		public void RemoveTile(int x, int y)
		{
			Grid[x, y] = new Tile();
		}

		public void SetBridge(int x, int y, int rotation)
		{
			throw new NotImplementedException();
		}

		public ITile[,] GetBoard()
		{
			return Grid;
		}
	}
}
