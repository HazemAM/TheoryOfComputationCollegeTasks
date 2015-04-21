using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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
		public int totalBlocks;

		int currentHeadPos = INITIAL;

		Storyboard scrollStoryboard;
		DoubleAnimation scrollAnimation;

		public Tape()
		{
			InitializeComponent();
			setupElements();
		}

		private void setupElements()
		{
			this.totalBlocks = tape.Children.Count - 1;

			scrollStoryboard = (Storyboard)this.Resources["scrollStoryboard"];
			scrollAnimation = (DoubleAnimation)this.Resources["scrollAnimation"];
		}

		public void start(string input)
		{
			this.input = input.ToCharArray();

			int headPos = this.totalBlocks / 2 - input.Length / 2 + 1;
			moveHeadToBlock(headPos);

			initializeInput(input, this.currentHeadPos);
		}

		private void initializeInput(string input, int startPos)
		{
			for(int i=0; i < totalBlocks; i++)
				(tape.Children[i] as BorderText).Text = string.Empty;
			for(int i=0; i < input.Length; i++)
				(tape.Children[startPos + i] as BorderText).Text = input[i].ToString();
		}

		/// <param name="index">0-based block index.</param>
		private void moveHeadToBlock(int index){
			tapeArrow.Margin = new Thickness(INITIAL + BLOCK_SIZE * index,
				tapeArrow.Margin.Top, tapeArrow.Margin.Right, tapeArrow.Margin.Bottom);
			this.currentHeadPos = index;
		}

		public bool moveRight(){
			if(this.currentHeadPos + 1 > this.totalBlocks)
				return false; //Out of GUI tape blocks.
			moveHeadToBlock(this.currentHeadPos + 1);
			return true;
		}

		public bool moveLeft(){
			if(this.currentHeadPos - 1 < 0)
				return false; //Out of GUI tape blocks.
			moveHeadToBlock(this.currentHeadPos - 1);
			return true;
		}

		public void write(char ch){
			(tape.Children[this.currentHeadPos] as BorderText).Text = ch.ToString();
		}
	}
}
