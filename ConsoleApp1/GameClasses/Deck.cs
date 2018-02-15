using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  public class Deck : IDeck
  {
		private List<Queue<ITile>> closedTiles;

		public List<ITile> OpenTiles { get; }

		public Deck(IPlayer player, List<int> amount)
		{
			closedTiles = new List<Queue<ITile>>(4) { new Queue<ITile>(), new Queue<ITile>(), new Queue<ITile>(), new Queue<ITile>() };
			for (int form = 0; form < closedTiles.Count; form++)
			{
				for (int i = 0; i < amount[form]; i++)
				{
					closedTiles[form].Enqueue(new Tile(form, player));
				}
			}

			OpenTiles = new List<ITile>(4) { TakeNewTile(), TakeNewTile(), TakeNewTile(), TakeNewTile() };

		}

		public ITile ChooseTile(int chosenTile)
		{
			ITile tile = OpenTiles[chosenTile];
			OpenTiles[chosenTile] = TakeNewTile();

			return tile;
		}

		private ITile TakeNewTile()
		{
			int cardForm = new Random().Next(0, 3);
			var newTile = closedTiles[cardForm].Dequeue();

			if (newTile == null)
			{
				if (closedTiles[0].Count == 0 && closedTiles[1].Count == 0 && closedTiles[2].Count == 0 && closedTiles[3].Count == 0)
					return new Tile();
				else
					return TakeNewTile();
			}
			else return newTile;
		}
	}
}
