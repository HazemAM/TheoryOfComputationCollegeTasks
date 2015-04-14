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
		const int TOTAL_BLOCKS = 23;

		int currentHeadPos = INITIAL;

		public Tape()
		{
			InitializeComponent();
		}

		public void start(string input)
		{
			this.input = input.ToCharArray();

			int headPos = TOTAL_BLOCKS / 2 - input.Length / 2 + 1;
			moveHeadToBlock(headPos);

			writeOnTape(input);
		}

		private void writeOnTape(string input)
		{
			for(int i=0; i < input.Length; i++)
				(tape.Children[currentHeadPos + i] as BorderText).Text = input[i].ToString();
		}

		/// <param name="index">1-based block index.</param>
		private void moveHeadToBlock(int index){
			tapeArrow.Margin = new Thickness(INITIAL + BLOCK_SIZE * index,
				tapeArrow.Margin.Top, tapeArrow.Margin.Right, tapeArrow.Margin.Bottom);
			currentHeadPos = index;
		}
	}
}
