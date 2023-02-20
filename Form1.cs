using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
	public partial class Form1 : Form
	{
		public static Form1 Instance { get; private set; }

		public static bool[,] Board = new bool[10, 10];
		public Form1()
		{
			InitializeComponent();
			Instance = this;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Program.Play();
		}

		public void readShipData(bool[,] GeneratedBoard)
		{
			Board = GeneratedBoard;
		}

		public DataGridView gridView()
		{
			return dataGridView1;
		}

		private void dataGridView1_CellClick(object sender,
	DataGridViewCellEventArgs e)
		{
			DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dataGridView1.CurrentCell;
			if (Board[e.RowIndex, e.ColumnIndex].Equals(true))
			{
				dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "HIT";
				dataGridView1.CurrentCell.Style.BackColor = Color.Red;
				buttonCell.Style.SelectionBackColor= Color.Red;
				textBox1.Text=Program.HitScan(e);
			}
			else
			{
				dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "MISS";
				dataGridView1.CurrentCell.Style.BackColor = Color.White;
				buttonCell.Style.SelectionBackColor = Color.White;
				textBox1.Text="MISS!";
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
