using System;
using System.Collections.Generic;
using System.Windows;

namespace TheoryOfComputation
{
	/// <summary>
	/// Interaction logic for MainWindow.
	/// </summary>
	public partial class MainWindow : Window
	{
		const char EMPTY = '\0';
		
		AddThreeMachine machine;
		int currentState;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void buttonStart_Click(object sender, RoutedEventArgs e)
		{
			canvas.reset();
			currentState = 0;

			string input = textInput.Text;
			machine = new AddThreeMachine(input);
			tape.start(input);

			buttonStep.IsEnabled = true;
			buttonFinish.IsEnabled = true;
		}

		private void buttonStep_Click(object sender, RoutedEventArgs e)
		{
			Tuple<int,char,Direction> output;

			if((output = machine.step()) != null)
				handleStep(output);
			if(output.Item1 == AddThreeMachine.FINAL_STATE)
				disableButtons();
		}

		private void buttonFinish_Click(object sender, RoutedEventArgs e)
		{
			Tuple<int,char,Direction> output;

			//TODO: Something similar to 'buttonStep_Click' (based on FINAL_STATE)?
			while((output = machine.step()) != null)
				handleStep(output);

			disableButtons();
		}

		private void disableButtons()
		{
			buttonStep.IsEnabled = false;
			buttonFinish.IsEnabled = false;
		}

		private void handleStep(Tuple<int, char, Direction> output)
		{
			tape.write(output.Item2);
			canvas.highlightState(output.Item1);
			canvas.highlightArrow(currentState, output.Item1);
			if(output.Item3 == Direction.RIGHT)
				tape.moveRight();
			else if(output.Item3 == Direction.LEFT)
				tape.moveLeft();

			currentState = output.Item1; //New state is the new current.
		}
	}
}
