using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SquaresMoving
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

		}
		
		//Global Variables
		Timer clock = new Timer();
		
		int n = 0;
		static Panel sqr1 = new Panel();
		static Panel sqr2 = new Panel();
		static Panel sqr3 = new Panel();
		static Panel sqr4 = new Panel();
		Button start = new Button();
		Panel[] panelsArray = {sqr1, sqr2, sqr3, sqr4};
		int moveLenght = 50;
	
		
		void Spin(object sender, EventArgs e){
			clock.Start();
		}
		
		void Spinning(object sender, EventArgs e){
			Panel curr = panelsArray[n];
			
			label1.Text = curr.Top.ToString();
			label2.Text = curr.Left.ToString();
			label3.Text = this.ClientSize.Width.ToString();
			label4.Text = ClientSize.Height.ToString();
			
			
			if (curr.Left <= this.ClientSize.Width - curr.Width && curr.Top == 0){
//				returnToBounds(curr);
				curr.Left += moveLenght;
			}
			else if (curr.Left >= this.ClientSize.Width - curr.Width && curr.Top <= this.ClientSize.Height - curr.Height){
//				returnToBounds(curr);
				curr.Top += moveLenght;
			}
			else if (curr.Top >= this.ClientSize.Height - curr.Height && curr.Left >= 0){
//				returnToBounds(curr);
				curr.Left -= moveLenght;
			}
			else if (curr.Left <= 0 && curr.Top > 0){
//				returnToBounds(curr);
				curr.Top -= moveLenght;
			}
			else{
				returnToBounds(curr);
			}
			if (n==3){
				n=0;
			}
			else{
				n++;
			}
			
		}
		
		void returnToBounds(Panel OOB){
			if (OOB.Left > ClientSize.Width - OOB.Width){
				OOB.Left = ClientSize.Width - OOB.Width +1;
			}
			if (OOB.Top > ClientSize.Height - OOB.Height){
				OOB.Top = ClientSize.Height - OOB.Height +1;
			}
			if (OOB.Left < 0){
				OOB.Left = 0;
			}
			if(OOB.Top < 0){
				OOB.Top = 0;
			}
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			//set Parent
			sqr1.Parent = this;
			sqr2.Parent = this;
			sqr3.Parent = this;
			sqr4.Parent = this;
			start.Parent = this;

			
			
			//Global Positioning
			int heightCenter = this.ClientSize.Height / 2;
			int widhtCenter = this.ClientSize.Width / 2;
			int mainHeight = this.ClientSize.Height;
			int mainWidth = this.ClientSize.Width;
			var center = new Point(widhtCenter, heightCenter);
			var TopLeft = new Point(0, 0);
			var TopRight = new Point(this.ClientSize.Width, 0);
			var BottomLeft = new Point(0, this.ClientSize.Height);
			var BottomRight = new Point(this.ClientSize.Width, this.ClientSize.Height);
			int sizeMulti = 1;
			var quarterSize = new Size(mainHeight / 4 * sizeMulti, mainHeight / 4 * sizeMulti);
			
			
			//Timer Proprierties
			clock.Interval = 2;
			clock.Tick += Spinning;
			
			
			//Positioning elements
			//Start Button
			start.Size = new Size(50,50);
			start.Text = "GIRAR";
			start.Location = new Point(center.X - (start.Size.Width/2), center.Y - (start.Size.Height/2));
			start.Click += Spin;
			
			
			
			//TopLeft Square
			sqr1.BackColor = Color.Red;
			sqr1.Size = quarterSize;
			sqr1.Location = new Point(TopLeft.X, TopLeft.Y);
			
			
			
			//TopRight Square
			sqr2.BackColor = Color.BlueViolet;
			sqr2.Size = quarterSize;
			sqr2.Location = new Point(TopRight.X - sqr2.Width, TopRight.Y);
			
			
			//BottomLeft Square
			sqr3.BackColor = Color.Yellow;
			sqr3.Size = quarterSize;
			sqr3.Location = new Point(BottomLeft.X, BottomLeft.Y - sqr3.Height);
			
			
			//BottomRight Square
			sqr4.BackColor = Color.Green;
			sqr4.Size = quarterSize;
			sqr4.Location = new Point(BottomRight.X - sqr4.Width, BottomRight.Y - sqr4.Height);	
		}
		void Button1Click(object sender, EventArgs e)
		{
			if (n == 3){
				n = 0;
			}
			else{
				n++;
			}
		}
		void showMen(object sender, EventArgs e)
		{
		}
	}
}
