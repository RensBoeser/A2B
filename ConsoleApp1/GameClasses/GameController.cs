using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  public class GameController : IGameController
  {
		private IPlayerController playerController;
		private IDrawManager drawManager;
		private IBoard board;

		public GameController(IDrawManager drawManager, IPlayer playerOne, IPlayer playerTwo, IBoard board)
		{
			playerController = new PlayerController(playerOne, playerTwo);
			this.board = board;
			this.drawManager = drawManager;
		}

		public void NextTurn()
		{
			playerController.NextTurn();

			drawManager.DrawBoard(board);
			drawManager.DrawText($"{playerController.Current.Name}'s turn.");
			drawManager.DrawDice(playerController.PlayerOne, playerController.PlayerTwo);
			drawManager.DrawDeck(playerController.PlayerOne, playerController.PlayerTwo);
		}

		public void SelectTile()
		{
			throw new NotImplementedException();
		}
		public void SelectTileRotation()
		{
			throw new NotImplementedException();
		}

		public void SelectTileLocation()
		{
			throw new NotImplementedException();
		}

		public void PlacedTile()
		{
			throw new NotImplementedException();
		}
	}
}
