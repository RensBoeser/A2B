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

		public void DrawBoard(IBoard board)
		{
			ITile[,] grid = board.GetBoard();

			string[] lines = new string[4] { string.Empty, string.Empty, string.Empty, string.Empty};

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

				for (int l = 0; l < lines.Length; l++)
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

		public void DrawDice(IPlayer playerOne, IPlayer playerTwo)
		{
			List<List<string>> drawableDice = new List<List<string>>()
			{
				GetDiceFormat(playerOne.Dice),
				GetDiceFormat(playerTwo.Dice)
			};
			string distance = " ";
			string distanceName = " ";
			if			(playerOne.Name.Length < 9) { distanceName += new string(' ', 9 - playerOne.Name.Length); }
			else if (playerOne.Name.Length > 9) { distance += new string(' ', playerOne.Name.Length - 9); }
			
			List<string> lines = new List<string>()
			{
				$"{playerOne.Name} {distanceName} {playerTwo.Name}",
				$"+ - - - + {distance} + - - - +",
				$"| {drawableDice[0][0]} {drawableDice[0][1]} {drawableDice[0][2]} | {distance} | {drawableDice[1][0]} {drawableDice[1][1]} {drawableDice[1][2]} |",
				$"| {drawableDice[0][3]} {drawableDice[0][4]} {drawableDice[0][5]} | {distance} | {drawableDice[1][3]} {drawableDice[1][4]} {drawableDice[1][5]} |",
				$"| {drawableDice[0][6]} {drawableDice[0][7]} {drawableDice[0][8]} | {distance} | {drawableDice[1][6]} {drawableDice[1][7]} {drawableDice[1][8]} |",
				$"+ - - - + {distance} + - - - +"
			};

			foreach (string line in lines)
			{
				Console.WriteLine(line);
			}

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

		public void DrawDeck(IPlayer playerOne, IPlayer playerTwo)
		{
			List<List<string>> lines = new List<List<string>>(2);
			List<IPlayer> players = new List<IPlayer>() { playerOne, playerTwo };
			for (int i = 0; i < players.Count; i++)
			{
				List<List<string>> forms = new List<List<string>>();
				foreach (var tile in players[i].Deck.OpenTiles)
				{
					forms.Add(new TileForms().Forms[tile.Form][tile.Rotation]);
				}
				lines.Add(new List<string>(5) { "+ - - - + - - - + - - - + - - - +",
																				string.Empty,
																				string.Empty,
																				string.Empty,
																				"+ - - - + - - - + - - - + - - - +"});

				for (int j = 0; j < 4; j++)
				{
					lines[i][1] += $"| {forms[j][0]} {forms[j][1]} {forms[j][2]} ";
					lines[i][2] += $"| {forms[j][3]} {forms[j][4]} {forms[j][5]} ";
					lines[i][3] += $"| {forms[j][6]} {forms[j][7]} {forms[j][8]} ";
				}
				lines[i][1] += "|";
				lines[i][2] += "|";
				lines[i][3] += "|";
			}

			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine(lines[0][i] + "   " + lines[1][i]);
			}
		}
	}
}
