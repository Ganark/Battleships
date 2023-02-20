namespace Battleships
{
	partial class Form1
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Metoda wymagana do obsługi projektanta — nie należy modyfikować
		/// jej zawartości w edytorze kodu.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(748, 400);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(90, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Start/Restart";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.dataGridView1.Size = new System.Drawing.Size(826, 360);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(319, 400);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(212, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "Press Start/Restart button to begin";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(12, 378);
			this.textBox2.MaximumSize = new System.Drawing.Size(250, 80);
			this.textBox2.MinimumSize = new System.Drawing.Size(250, 40);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(250, 45);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "How to win:\r\nSink 2 enemy Destroyers, size 4x1\r\nSink 1 enemy Battleship, size 5x1" +
    "";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(850, 435);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Battleships";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
	}
}

