using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
	public enum Difficulty
	{
		Easy, 
		Medium,
		Hard,
	}
	public partial class Form2 : Form
	{
		private Difficulty difficulty;
		private Form1 gameForm;
		public Form2()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			gameForm = new Form1(difficulty);
			gameForm.ShowDialog();
			Hide();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			difficulty = Difficulty.Easy;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			difficulty = Difficulty.Medium;
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			difficulty = Difficulty.Hard;
		}
	}
}
