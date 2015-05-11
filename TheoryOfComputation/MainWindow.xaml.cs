﻿using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
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
		MachineStatus status;
		DispatcherTimer fastRunTimer;
		Tuple<int,char,Direction,char> output;
		int currentState;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void buttonStart_Click(object sender, RoutedEventArgs e)
		{
			string input = textInput.Text;

			while(input.Length >= tape.totalBlocks){
				tape.expandRight();
				tape.expandLeft();
			}

			canvas.reset();
			currentState = 0;

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
			if((output = machine.step(out status)) != null)
				handleStep(output);
			if(status != MachineStatus.CONTINUE) //Stop the UI when the machine hangs or halts.
				disableButtons();
		}

		private void buttonFinish_Click(object sender, RoutedEventArgs e)
		{
			while((output = machine.step(out status)) != null)
				handleStep(output);

			disableButtons();
		}

		private void buttonFastRun_Click(object sender, RoutedEventArgs e)
		{
			disableButtons(); //Disable the buttons while the animation is running.

			fastRunTimer = new DispatcherTimer{ Interval = TimeSpan.FromSeconds(0.25) };
			fastRunTimer.Tick += (o,ev) =>
			{
				if((output = machine.step(out status)) != null)
					handleStep(output);
				if(status != MachineStatus.CONTINUE)
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

		private bool handleStep(Tuple<int,char,Direction,char> output)
		{
			bool result;

			if(output.Item2 != AddThreeMachine.EMPTY)
				tape.write(output.Item2);

			canvas.highlightState(output.Item1);
			canvas.highlightArrow(currentState, output.Item1);
			canvas.highlightFunction(currentState, output.Item4);

			if(output.Item3 == Direction.RIGHT)
				result = tape.moveRight();
			else if(output.Item3 == Direction.LEFT)
				result = tape.moveLeft();
			else result = true;

			currentState = output.Item1; //New state is the new current.

			return result;
		}

		private void Window_KeyPress(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter && !buttonStep.IsFocused && !buttonFastRun.IsFocused
				 && !buttonFinish.IsFocused && e.IsDown){
				e.Handled = true;
				click(buttonStart);
			}
			else if(e.Key == Key.Enter && buttonStart.IsFocused && e.IsUp){
				e.Handled = true;
				release(buttonStart);
			}

			else if(e.Key == Key.Right && buttonStep.IsEnabled && e.IsDown){
				e.Handled = true;
				click(buttonStep);

				if(!buttonStep.IsEnabled)
					buttonStart.Focus();
			}
			else if(e.Key == Key.Right && e.IsUp){
				e.Handled = true;
				release(buttonStep);
			}
		}

		private void click(Button button)
		{
			button.Focus();
			button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
			typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(button, new object[] { true });
		}

		private void release(Button button)
		{
			typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(button, new object[] { false });
		}
	}
}
