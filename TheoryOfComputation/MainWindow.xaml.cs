using System;
using System.Windows;
using System.Windows.Threading;

namespace TheoryOfComputation
{
	/// <summary>
	/// Interaction logic for MainWindow.
	/// </summary>
	public partial class MainWindow : Window
	{
		const char EMPTY = '\0';
		
		AddThreeMachine machine;
		DispatcherTimer fastRunTimer;
		Tuple<int,char,Direction,char> output;
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
			buttonFastRun.IsEnabled = true;

			if(fastRunTimer != null)
				fastRunTimer.IsEnabled = false;
		}

		private void buttonStep_Click(object sender, RoutedEventArgs e)
		{
			if((output = machine.step()) != null)
				handleStep(output);
			if(output.Item1 == AddThreeMachine.FINAL_STATE)
				disableButtons();
		}

		private void buttonFinish_Click(object sender, RoutedEventArgs e)
		{
			while((output = machine.step()) != null)
				handleStep(output);

			disableButtons();
		}

		private void buttonFastRun_Click(object sender, RoutedEventArgs e)
		{
			disableButtons(); //Disable the buttons while the animation is running.

			fastRunTimer = new DispatcherTimer{ Interval = TimeSpan.FromSeconds(0.25) };
			fastRunTimer.Tick += (o,ev) =>
			{
				if((output = machine.step()) != null)
					handleStep(output);
				if(output.Item1 == AddThreeMachine.FINAL_STATE)
					fastRunTimer.IsEnabled = false;
			};
			fastRunTimer.IsEnabled = true;
		}

		private void disableButtons()
		{
			buttonStep.IsEnabled = false;
			buttonFinish.IsEnabled = false;
			buttonFastRun.IsEnabled = false;
		}

		private void handleStep(Tuple<int,char,Direction,char> output)
		{
			if(output.Item2 != AddThreeMachine.EMPTY)
				tape.write(output.Item2);
			canvas.highlightState(output.Item1);
			canvas.highlightArrow(currentState, output.Item1);
			canvas.highlightFunction(currentState, output.Item4);
			if(output.Item3 == Direction.RIGHT)
				tape.moveRight();
			else if(output.Item3 == Direction.LEFT)
				tape.moveLeft();

			currentState = output.Item1; //New state is the new current.
		}
	}
}
