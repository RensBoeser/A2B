using System;
using System.Collections.Generic;
using System.Text;

namespace Akkers2Beurs
{
  public class TerminalDrawManager : IDrawManager
  {

		class TileForms
		{
			public List<List<List<string>>> Forms { get; set; }
			public List<string> Empty { get; set; }

			private List<List<string>> Straight;
			private List<List<string>> Turn;
			private List<List<string>> Tcross;
			private List<List<string>> Cross;

			public TileForms()
			{
				Empty = new List<string>() { " ", " ", " ",
																		 " ", " ", " ",
																		 " ", " ", " "};

				Straight = new List<List<string>>
				{
					new List<string>() { " ", "|", " ",
															 " ", "|", " ",
															 " ", "|", " "},
					new List<string>() { " ", " ", " ",
															 "-", "-", "-",
															 " ", " ", " "}
				};
				Turn = new List<List<string>>
				{
					new List<string>() { " ", " ", " ",
															 " ", "+", "-",
															 " ", "|", " "},
					new List<string>() { " ", " ", " ",
															 "-", "+", " ",
															 " ", "|", " "},
					new List<string>() { " ", "|", " ",
															 "-", "+", " ",
															 " ", " ", " "},
					new List<string>() { " ", "|", " ",
															 " ", "+", "-",
															 " ", " ", " "}
				};
				Tcross = new List<List<string>>
				{
					new List<string>() { " ", " ", " ",
															 "-", "+", "-",
															 " ", "|", " "},
					new List<string>() { " ", "|", " ",
															 "-", "+", " ",
															 " ", "|", " "},
					new List<string>() { " ", "|", " ",
															 "-", "+", "-",
															 " ", " ", " "},
					new List<string>() { " ", "|", " ",
															 " ", "+", "-",
															 " ", "|", " "}
				};
				Cross = new List<List<string>>
				{
					new List<string>() { " ", "|", " ",
															 "-", "+", "-",
															 " ", "|", " "}
				};

				Forms = new List<List<List<string>>>() { Straight, Turn, Tcross, Cross };
			}
		}

		private List<string> Player(IPlayer player, bool showDice = true, bool showDeck = true)
		{
			List<string> lines = new List<string>() { "Player: " + player.Name };
			if (showDice) foreach (string line in Dice(player.Dice)) lines.Add(line);
			if (showDeck) foreach (string line in Deck(player.Deck)) lines.Add(line);

			int longest = 0;
			foreach (string line in lines)
			{
				if (line.Length > longest) longest = line.Length;
			}

			for (int i = 0; i < lines.Count; i++)
			{
				while(lines[i].Length < longest)
				{
					lines[i] += ' ';
				}
			}

			return lines;
		}

		public void NextTurnScene(IBoard board, IPlayer playerOne, IPlayer playerTwo)
		{
			List<string> drawablePlayerOne = Player(playerOne);
			List<string> drawablePlayerTwo = Player(playerTwo);

			Board(board); //make sure this function RETURNS the string rather than print it.

			for (int i = 0; i < drawablePlayerOne.Count; i++)
			{
				Console.WriteLine(drawablePlayerOne[i] + "   " + drawablePlayerTwo[i]);
			}
		}

		private void Board(IBoard board)
		{
			ITile[,] grid = board.GetBoard();

			List<string> lines = new List<string>(4) { string.Empty, string.Empty, string.Empty, string.Empty};

			for (int i = 0; i < grid.GetLength(0); i++)
			{
				for (int j = 0; j < grid.GetLength(1); j++)
				{
					//string form = (grid[i, j].Form).ToString();
					//if (form == "-1") form = "N";
					List<string> form;

					if (grid[j, i].Form == -1) form = new TileForms().Empty;
					else form = new TileForms().Forms[grid[j, i].Form][grid[j, i].Rotation];

					lines[0] += $"+ - - - ";
					lines[1] += $"| {form[0]} {form[1]} {form[2]} ";
					lines[2] += $"| {form[3]} {form[4]} {form[5]} ";
					lines[3] += $"| {form[6]} {form[7]} {form[8]} ";
				}

				lines[0] += "+";
				lines[1] += "|";
				lines[2] += "|";
				lines[3] += "|";

				for (int l = 0; l < lines.Count; l++)
				{
					Console.WriteLine(lines[l]);
					lines[l] = string.Empty;
				}
			}
			for (int l = 0; l < grid.GetLength(0); l++)
			{
				Console.Write("+ - - - ");
			}
			Console.WriteLine("+");
		}

		private List<string> Dice(int diceRoll)
		{
			List<string> diceForm = GetDiceFormat(diceRoll);
			List<string> lines = new List<string>()
			{
				"+ - - - +",
				$"| {diceForm[0]} {diceForm[1]} {diceForm[2]} |",
				$"| {diceForm[3]} {diceForm[4]} {diceForm[5]} |",
				$"| {diceForm[6]} {diceForm[7]} {diceForm[8]} |",
				"+ - - - +"
			};

			return lines;
		}

		private List<string> GetDiceFormat(int playerRoll)
		{
			switch (playerRoll)
			{
				case 1:
					return new List<string>() { " ", " ", " ",
																			" ", "+", " ",
																			" ", " ", " "};
				case 2:
					return new List<string>() { "+", " ", " ",
																			" ", " ", " ",
																			" ", " ", "+"};
				case 3:
					return new List<string>() { "+", " ", " ",
																			" ", "+", " ",
																			" ", " ", "+"};
				case 4:
					return new List<string>() { "+", " ", "+",
																			" ", " ", " ",
																			"+", " ", "+"};
				case 5:
					return new List<string>() { "+", " ", "+",
																			" ", "+", " ",
																			"+", " ", "+"};
				case 6:
					return new List<string>() { "+", " ", "+",
																			"+", " ", "+",
																			"+", " ", "+"};
				default:
					return new List<string>() { " ", " ", " ",
																			" ", " ", " ",
																			" ", " ", " "};
			}
		}

		public void DrawText(string text)
		{
			Console.WriteLine(text);
		}

		private List<string> Deck(IDeck deck)
		{
			List<List<string>> forms = new List<List<string>>()
			{
				new TileForms().Forms[deck.OpenTiles[0].Form][deck.OpenTiles[0].Rotation],
				new TileForms().Forms[deck.OpenTiles[1].Form][deck.OpenTiles[1].Rotation],
				new TileForms().Forms[deck.OpenTiles[2].Form][deck.OpenTiles[2].Rotation],
				new TileForms().Forms[deck.OpenTiles[3].Form][deck.OpenTiles[3].Rotation],
			};

			List<string> lines = new List<string>()
			{ "+ - - - + - - - + - - - + - - - +",
				string.Empty,
				string.Empty,
				string.Empty,
				"+ - - - + - - - + - - - + - - - +"
			};

			for (int i = 0; i < 4; i++)
			{
				lines[1] += $"| {forms[i][0]} {forms[i][1]} {forms[i][2]} ";
				lines[2] += $"| {forms[i][3]} {forms[i][4]} {forms[i][5]} ";
				lines[3] += $"| {forms[i][6]} {forms[i][7]} {forms[i][8]} ";
			}
			lines[1] += "|";
			lines[2] += "|";
			lines[3] += "|";

			return lines;
		}
	}
}
