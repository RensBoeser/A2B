using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  public interface IDeck
  {
		List<ITile> OpenTiles { get; }
		ITile ChooseTile(int chosenTile);
  }
}
