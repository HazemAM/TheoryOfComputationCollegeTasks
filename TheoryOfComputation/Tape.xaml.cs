using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

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
		const int EXPANSION = 2;

		public int totalBlocks;
		int currentHeadPos = INITIAL;

		double globalArrowOffset = 0;

		Storyboard scrollStoryboard;
		DoubleAnimation scrollAnimation;

		public Tape()
		{
			InitializeComponent();
			setupElements();
		}

		private void setupElements()
		{
			updateTotalBlocks();

			scrollStoryboard = (Storyboard)this.Resources["scrollStoryboard"];
			scrollAnimation = (DoubleAnimation)this.Resources["scrollAnimation"];
		}

		public void start(string input)
		{
			this.input = input.ToCharArray();

			int headPos = this.totalBlocks / 2 - input.Length / 2 + 1;
			moveHeadToBlock(headPos);
			scrollReset();

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
			while(this.currentHeadPos + 1 > this.totalBlocks)
				expandRight();

			moveHeadToBlock(this.currentHeadPos + 1);
			scrollRight();

			return true;
		}

		public bool moveLeft(){
			while(this.currentHeadPos - 1 < 0)
				expandLeft();

			moveHeadToBlock(this.currentHeadPos - 1);
			scrollLeft();

			return true;
		}

		public void expandRight()
		{
			(tape.Children[tape.Children.Count - 1] as BorderText).Last = false;
			for(int i=0; i < EXPANSION; i++)
				tape.Children.Add(new BorderText());
			(tape.Children[tape.Children.Count - 1] as BorderText).Last = true;

			updateTotalBlocks();
		}

		public void expandLeft()
		{
			for(int i=0; i < EXPANSION; i++)
				tape.Children.Insert(0, new BorderText());
			this.currentHeadPos += EXPANSION;

			updateTotalBlocks();
		}

		private void scrollRight()
		{
			//Required timer for updating 'ScrollableWidth' to use in the animation:
			DispatcherTimer noteScrollTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1) };
			noteScrollTimer.Tick += (source, args) =>
			{
				scrollAnimation.To = (this.globalArrowOffset += BLOCK_SIZE);
				scrollStoryboard.Begin();
				noteScrollTimer.Stop();
			};
			noteScrollTimer.Start();
		}

		private void scrollLeft()
		{
			//Required timer for updating 'ScrollableWidth' to use in the animation:
			DispatcherTimer noteScrollTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1) };
			noteScrollTimer.Tick += (source, args) =>
			{
				scrollAnimation.To = (this.globalArrowOffset -= BLOCK_SIZE);
				scrollStoryboard.Begin();
				noteScrollTimer.Stop();
			};
			noteScrollTimer.Start();
		}

		private void scrollReset()
		{
			scrollAnimation.To = this.globalArrowOffset = 0;
			scrollStoryboard.Begin();
		}

		private void updateTotalBlocks()
		{
			this.totalBlocks = tape.Children.Count - 1;
		}

		public void write(char ch){
			(tape.Children[this.currentHeadPos] as BorderText).Text = ch.ToString();
		}
	}
}
