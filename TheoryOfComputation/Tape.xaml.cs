using System;
using System.Windows;
using System.Windows.Controls;

namespace TheoryOfComputation
{
	/// <summary>
	/// Interaction logic for Tape.xaml
	/// </summary>
	public partial class Tape : UserControl
	{
		char[] input;
		const int INITIAL = 5;
		const int BLOCK_SIZE = 28;
		int totalBlocks;

		int currentHeadPos = INITIAL;

		public Tape()
		{
			InitializeComponent();
			this.totalBlocks = tape.Children.Count - 1;
		}

		public void start(string input)
		{
			this.input = input.ToCharArray();

			int headPos = this.totalBlocks / 2 - input.Length / 2 + 1;
			moveHeadToBlock(headPos);

			writeOnTape(input, this.currentHeadPos);
		}

		private void writeOnTape(string input, int startPos)
		{
			for(int i=0; i < input.Length; i++)
				(tape.Children[startPos + i] as BorderText).Text = input[i].ToString();
		}

		/// <param name="index">0-based block index.</param>
		private void moveHeadToBlock(int index){
			tapeArrow.Margin = new Thickness(INITIAL + BLOCK_SIZE * index,
				tapeArrow.Margin.Top, tapeArrow.Margin.Right, tapeArrow.Margin.Bottom);
			this.currentHeadPos = index;
		}

		public void moveRight(){
			if(this.currentHeadPos + 1 > this.totalBlocks)
				throw new ArgumentOutOfRangeException("Out of GUI tape blocks");
			moveHeadToBlock(this.currentHeadPos + 1);
		}

		public void moveLeft(){
			if(this.currentHeadPos - 1 < 0)
				throw new ArgumentOutOfRangeException("Out of GUI tape blocks");
			moveHeadToBlock(this.currentHeadPos - 1);
		}

		public void write(char ch){
			(tape.Children[this.currentHeadPos] as BorderText).Text = ch.ToString();
		}
	}
}
