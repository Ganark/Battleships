using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		public static bool[,] Board = new bool[10, 10];

		public static List<string> Battleship = new List<string>();
		public static List<string> Destroyer1 = new List<string>();
		public static List<string> Destroyer2 = new List<string>();


		private static void BoardSetup()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					Board[i, j] = false;
				}
			}
		}

		private static Random rnd = new Random();
		private static List<string> DestroyerSetup()
		{
			int spotX;
			int spotY;
			int horizontal;
			List<string> returnList = new List<string>();

			
			horizontal = rnd.Next(0, 2);//pick alignment

			if (horizontal == 1)//check if available and draw
			{
				spotX = rnd.Next(0, 7);//pick first square
				spotY = rnd.Next(0, 10);
				for (int i = 0; i < 4; i++)
				{
					if (Board[spotX + i, spotY] == true)
					{
						return DestroyerSetup();
					}
				}
				for (int j = 0; j < 4; j++)
				{
					int X = spotX + j;
					int Y = spotY;
					Board[X, Y] = true;
					string location = X + " " + Y;
					returnList.Add(location);
				}
			}
			else
			{
				spotX = rnd.Next(0, 10);//pick first square
				spotY = rnd.Next(0, 7);
				for (int i = 0; i < 4; i++)
				{
					if (Board[spotX, spotY + i] == true)
					{
						return DestroyerSetup();
					}
				}
				for (int j = 0; j < 4; j++)
				{
					int X = spotX;
					int Y = spotY + j;
					Board[X, Y] = true;
					string location = X + " " + Y;
					returnList.Add(location);
				}
			}
			return returnList;
		}
		private static List<string> BattleshipSetup()
		{
			int spotX;
			int spotY;
			int horizontal;
			List<string> returnList = new List<string>();

			horizontal = rnd.Next(0, 2);//pick alignment

			if (horizontal == 1)//check if available and draw
			{
				spotX = rnd.Next(0, 6);//pick first square
				spotY = rnd.Next(0, 10);
				for (int i = 0; i < 5; i++)
				{
					if (Board[spotX + i, spotY] == true)
					{
						return BattleshipSetup(); 
					}
				}
				for (int j = 0; j < 5; j++)
				{
					int X = spotX + j;
					int Y = spotY;
					Board[X, Y] = true;
					string location = X + " " + Y;
					returnList.Add(location);
				}
			}
			else
			{
				spotX = rnd.Next(0, 10);//pick first square
				spotY = rnd.Next(0, 6);
				for (int i = 0; i < 5; i++)
				{
					if (Board[spotX, spotY + i] == true)
					{
						return BattleshipSetup();
					}
				}
				for (int j = 0; j < 5; j++)
				{
					int X = spotX;
					int Y = spotY + j;
					Board[X, Y] = true;
					string location = X + " " + Y;
					returnList.Add(location);
				}
			}
			return returnList;
		}
		private static void ShipCreator()
		{
			Destroyer1 = DestroyerSetup();
			Destroyer2 = DestroyerSetup();
			Battleship = BattleshipSetup();
		}

		private static void DrawArea()
		{
			DataGridView gridView = Form1.Instance.gridView();
			gridView.Enabled = true;
			gridView.AllowUserToAddRows = false;
			gridView.Rows.Clear();
			gridView.Columns.Clear();
			gridView.Refresh();
			gridView.ColumnCount = 0;
			gridView.RowCount = 0;
			for (int i = 0; i < 10; i++)
			{
				DataGridViewButtonColumn button = new DataGridViewButtonColumn();
				{
					button.Name = "button";
					button.HeaderText = (i + 1).ToString();
					button.Text = "UNKNOWN";
					button.UseColumnTextForButtonValue = false;
					button.DefaultCellStyle.BackColor = Color.Blue;
					button.DefaultCellStyle.SelectionBackColor = Color.Blue;
					gridView.Columns.Insert(i, button);
				}
			}
			for (int i = 0; i < 10; i++)
			{
				DataGridViewRow row = new DataGridViewRow();
				row.CreateCells(gridView);
				for (int j = 0; j < 10; j++)
				{
					row.Cells[j].Value = "UNKNOWN";
					row.HeaderCell.Value = ((char)(i + 65)).ToString();
				}



				row.SetValues("UNKNOWN");
				gridView.Rows.Add(row);
				gridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}
			gridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			int totalRowHeight = gridView.ColumnHeadersHeight;
			foreach (DataGridViewRow row in gridView.Rows)
			{
				totalRowHeight += row.Height;
			}

			if (totalRowHeight < gridView.Height)
			{
				totalRowHeight = gridView.Height;
				totalRowHeight -= gridView.ColumnHeadersHeight;
				int rowHeight = totalRowHeight / gridView.Rows.Count;

				foreach (DataGridViewRow row in gridView.Rows)
				{
					row.MinimumHeight = rowHeight;
				}
				gridView.Refresh();

			}
			Form1.Instance.readShipData(Board);
		}
		public static void Play()
		{
			GC.Collect();
			BoardSetup();
			ShipCreator();
			DrawArea();
		}

		public static string HitScan(DataGridViewCellEventArgs data)
		{
			string shotCoordinates = data.RowIndex.ToString() + " " + data.ColumnIndex.ToString();
			if (Destroyer1.Contains(shotCoordinates))
			{
				return SinkWinCheck(0, shotCoordinates);
			}
			else if (Destroyer2.Contains(shotCoordinates))
			{
				return SinkWinCheck(1, shotCoordinates);
			}
			else if (Battleship.Contains(shotCoordinates))
			{
				return SinkWinCheck(2, shotCoordinates);
			}
			else
			{
				return "MISS!";
			}
		}
		public static string SinkWinCheck(int data, string shotCoordinates)
		{
			switch (data)
			{
				case 0:
					Destroyer1.Remove(shotCoordinates);
					if (!Destroyer1.Any())
					{
						if (!Destroyer1.Any() && !Destroyer2.Any() && !Battleship.Any())
						{
							Form1.Instance.gridView().Enabled = false;
							return "Destroyer sunk! You win!";
						}
						return "Destroyer sunk!";
					}
					else
					{
						return "Destroyer hit!";
					}
				case 1:
					Destroyer2.Remove(shotCoordinates);
					if (!Destroyer2.Any())
					{
						if (!Destroyer1.Any() && !Destroyer2.Any() && !Battleship.Any())
						{
							Form1.Instance.gridView().Enabled = false;
							return "Destroyer sunk! You win!";
						}
						return "Destroyer sunk!";
					}
					else
					{
						return "Destroyer hit!";
					}
				case 2:
					Battleship.Remove(shotCoordinates);
					if (!Battleship.Any())
					{
						if (!Destroyer1.Any() && !Destroyer2.Any() && !Battleship.Any())
						{
							Form1.Instance.gridView().Enabled = false;
							return "Battleship sunk! You win!";
						}
						return "Battleship sunk!";
					}
					else
					{
						return "Battleship hit!";
					}
				default:
					return "Error!";
			}
		}
	}
}
